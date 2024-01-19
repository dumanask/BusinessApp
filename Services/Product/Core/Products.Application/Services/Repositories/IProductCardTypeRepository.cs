using BusinessApp.Shared.Application.Services;
using Products.Domain;

namespace Products.Application.Services.Repositories;

public interface IProductCardTypeRepository : IAsyncRepository<ProductCardType, Guid>
{
    
}