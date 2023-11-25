using System.Reflection;
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}