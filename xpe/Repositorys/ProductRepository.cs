using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using xpe.Data;
using xpe.Interfaces.Repositorys;
using xpe.Models;

namespace xpe.Repositorys;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Product> _dbSet;
    
    public ProductRepository(AppDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _context.Set<Product>();
    }

    public async Task<List<Product>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<Product>> Search(Expression<Func<Product, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<Product> Add(Product product)
    {
        try
        {
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
        
            return product;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Ocorreu um erro ao adicionar o produto.", ex);
        }
    }

    public async Task<Product> Update(Product product)
    {
        try
        {
            _dbSet.Update(product);
            await _context.SaveChangesAsync();
        
            return product;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Ocorreu um erro ao atualizar o produto.", ex);
        }
    }

    public async Task Delete(Guid id)
    {
        try
        {
            var product = await _dbSet.FindAsync(id);
            
            if (product == null) throw new ApplicationException("Produto não encontrado!");
            
            _dbSet.Remove(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Ocorreu um erro ao remover o produto.", ex);
        }
    }

    public async Task<int> Count()
    {
        return await _dbSet.CountAsync();
    }

    public void Dispose()
    {
       _context.Dispose();
    }
}