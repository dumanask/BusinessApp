using Products.Domain;
using Shared;

namespace Products.Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, Guid>
{
    
}