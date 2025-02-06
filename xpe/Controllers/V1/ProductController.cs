using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using xpe.DTOs;
using xpe.Interfaces;
using xpe.Interfaces.Services;
using xpe.Models;

namespace xpe.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductController : MainController
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductController(IProductService productService
                               , IMapper mapper
                               , INotifier notifier) : base(notifier)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET api/v1/products
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAll();

            var productsDTO = _mapper.Map<List<ProductDTO>>(products);

            return CustomResponse(productsDTO);
        }

        // GET api/v1/products/{id}
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductDTO>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                _notifier.Handle("ID do produto é inválido.");
                return CustomResponse();
            }
            
            var product = await _productService.GetById(id);

            if (product == null)
            {
                _notifier.Handle("Produto não encontrado!");
                return CustomResponse();
            }

            var dto = _mapper.Map<ProductDTO>(product);

            return CustomResponse(dto);
        }

        // POST api/v1/products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Add([FromBody] ProductDTO productDTO)
        {
            try
            {
                if(!ModelState.IsValid) return CustomResponse(ModelState);
                
                var product = _mapper.Map<Product>(productDTO);

                var result = await _productService.Add(product);

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                {
                    _notifier.Handle(ex.Message);
                    return CustomResponse();
                }

                _notifier.Handle($"Error: Ocoreu um erro ao adiconar produto: {ex}");
                return CustomResponse();
            }
        }

        // PUT api/v1/products/{id}
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ProductDTO>> Update(Guid id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);
                
                if (id != productDTO.Id)
                {
                    _notifier.Handle("Os ids informados não são iguais!");
                    return CustomResponse();
                }
                
                var existingProduct = await _productService.GetById(id);

                if (existingProduct == null)
                {
                    _notifier.Handle("Produto não encontrado.");
                    return CustomResponse();
                }
                
                var product = _mapper.Map(productDTO, existingProduct);

                var result = await _productService.Update(product);

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                {
                    _notifier.Handle(ex.Message);
                    return CustomResponse();
                }

                _notifier.Handle($"Error: Ocoreu um erro ao atualizar produto: {ex}");
                return CustomResponse();
            }
        }

        // PATCH api/v1/products/{id}
        [HttpPatch("{id:Guid}")]
        public async Task<ActionResult<ProductDTO>> Patch(Guid id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                {
                    _notifier.Handle("Dados não informados!");
                    return CustomResponse();
                }
        
                var existingProduct = await _productService.GetById(id);
                if (existingProduct == null)
                {
                    _notifier.Handle("Produto não encontrado!");
                    return CustomResponse();
                }
        
                var product = _mapper.Map(productDTO, existingProduct);
                
                if (productDTO.Price <= 0) 
                {
                    product.Price = existingProduct.Price;
                }
        
                var result = await _productService.Update(product);
        
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                {
                    _notifier.Handle(ex.Message);
                    return CustomResponse();
                }
        
                _notifier.Handle($"Error: Ocoreu um erro ao atualizar produto: {ex}");
                return CustomResponse();
            }
        }

        // DELETE api/v1/products/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    _notifier.Handle("O Id informado não válido!");
                    return CustomResponse();
                }

                await _productService.Delete(id);

                return CustomResponse();
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                {
                    _notifier.Handle(ex.Message);
                    return CustomResponse();
                }

                _notifier.Handle($"Error: Ocoreu um erro ao remover produto: {ex}");
                return CustomResponse();
            }
        }
    }
}
