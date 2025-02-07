using xpe.Interfaces;
using xpe.Interfaces.Repositorys;
using xpe.Interfaces.Services;
using xpe.Models;
using xpe.Models.Validations;

namespace xpe.Services;

public class ProductService : BasicService, IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
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
        if (!RunValidation(new ProductValidation(), product)) return null;

        return await _productRepository.Add(product);
    }

    public async Task<Product> Update(Product product)
    {
        if (!RunValidation(new ProductValidation(), product)) return null;

        return await _productRepository.Update(product);
    }

    public async Task Delete(Guid id)
    {
        await _productRepository.Delete(id);
        
        return;
    }

    public async Task<int> Count()
    {
        return await _productRepository.Count();
    }

    public async Task<List<Product>> GetByName(string name)
    {
        return await _productRepository.Search(cd => cd.Name.ToUpper().Contains(name.ToUpper()));
    }
}