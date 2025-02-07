using xpe.Models;

namespace xpe.Interfaces.Services;

public interface IProductService
{
    Task<int> Count();
    Task<List<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task<List<Product>> GetByName(string name);
    Task<Product> Add(Product product);
    Task<Product> Update(Product product);
    Task Delete(Guid id);
}