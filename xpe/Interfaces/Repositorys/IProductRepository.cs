using System.Linq.Expressions;
using xpe.Models;

namespace xpe.Interfaces.Repositorys;

public interface IProductRepository : IDisposable
{
    Task<int> Count();
    Task<List<Product>> Search(Expression<Func<Product, bool>> predicate);
    Task<List<Product>> GetAll();
    Task<Product> GetById(Guid id);
    Task<Product> Add(Product product);
    Task<Product> Update(Product product);
    Task Delete(Guid id);
}