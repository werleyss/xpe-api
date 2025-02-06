using xpe.Interfaces.Repositorys;
using xpe.Interfaces.Services;
using xpe.Models;

namespace xpe.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<List<Product>> GetAll()
    {
        return await _productRepository.GetAll();
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<Product> Add(Product product)
    {
        return await _productRepository.Add(product);
    }

    public async Task<Product> Update(Product product)
    {
        return await _productRepository.Update(product);
    }

    public async Task Delete(Guid id)
    {
        await _productRepository.Delete(id);
        
        return;
    }
}