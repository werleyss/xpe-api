using Microsoft.EntityFrameworkCore;
using xpe.Models;

namespace xpe.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                entry.Property("UpdatedAt").CurrentValue = null;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("Id").IsModified = false;
                entry.Property("CreatedAt").IsModified = false;
                entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    
    public DbSet<Product> Products { get; set; }
}