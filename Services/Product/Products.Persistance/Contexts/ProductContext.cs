using System.Reflection;
using BusinessApp.Shared.Constants.Products;
using BusinessApp.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain;

namespace Products.Persistance.Contexts;

public class ProductContext : DbContext
{
    protected IConfiguration Configuration { get; }
    public ProductContext(DbContextOptions<ProductContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCardType> ProductCardTypes { get; set; }
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

}