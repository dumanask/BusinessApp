using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Services.Repositories;
using Products.Persistance.Contexts;
using Products.Persistance.Services.Repositories;

namespace Products.Persistance.Extensions;

public static class PersistanceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {



        services.AddDbContext<ProductContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), opt =>
            {

                opt.EnableRetryOnFailure();
            });
        });

        services.AddScoped<IProductCardTypeRepository, ProductCardTypeRepository>();
        services.AddScoped<IProductCatalogRepository, ProductCatalogRepository>();
        services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
        services.AddScoped<IProductModelTypeRepository, ProductModelTypeRepository>();
        services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();


        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        return services;
    }
    
}