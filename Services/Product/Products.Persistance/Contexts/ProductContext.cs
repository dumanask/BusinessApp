using System.Reflection;
using BusinessApp.Shared.Constants.Products;
using BusinessApp.Shared.Domain.Models;
using BusinessApp.Shared.Domain.Models.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain;

namespace Products.Persistance.Contexts;

public class ProductContext : DbContext
{
    public ProductContext()
    {
            
    }
    public ProductContext(DbContextOptions options) : base(options)
    {
      
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCardType> ProductCardTypes { get; set; }
    public DbSet<ProductCatalog> ProductCatalogs { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductModelType> ProductModelTypes { get; set; }
    public DbSet<ProductStatus> ProductStatuses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = ProductsConstants.DefaultConnectionString;
            optionsBuilder.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void OnBeforeSave()
    {
        var addedEntities = ChangeTracker.Entries()
                            .Where(i => i.State == EntityState.Added)
                            .Select(i => (BaseEntity)i.Entity);
        SetCreatedDatesOfEntities(addedEntities);
    }

    public void SetCreatedDatesOfEntities(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
            entity.CreatedDate = DateTime.Now;
    }

}