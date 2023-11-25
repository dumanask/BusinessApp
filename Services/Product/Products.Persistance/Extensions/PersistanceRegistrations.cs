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
        services.AddScoped<IProductRepository, ProductRepository>();


        services.AddDbContext<ProductContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BusinesApp"), opt =>
            {

                opt.EnableRetryOnFailure();
            });
        });

        return services;
    }
    
}