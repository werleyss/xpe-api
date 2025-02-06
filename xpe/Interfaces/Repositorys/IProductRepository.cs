using xpe.Models;

namespace xpe.Interfaces.Repositorys;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task<Product> Add(Product product);
    Task<Product> Update(Product product);
    Task Delete(Guid id);
}