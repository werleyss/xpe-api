using Microsoft.EntityFrameworkCore;
using xpe.Data;
using xpe.Interfaces.Repositorys;
using xpe.Models;

namespace xpe.Repositorys;

public class ProductRepository : IProductRepository
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<Product> _dbSet;
    
    public ProductRepository(AppDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _context.Set<Product>();
    }
    
    public Task<List<Product>> GetAll()
    {
        return Task.FromResult(new List<Product>());
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<Product> Add(Product product)
    {
        await _dbSet.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        return await Task.FromResult(new Product());
    }

    public Task Delete(Guid id)
    {
        return Task.FromResult(new Product());
    }
}