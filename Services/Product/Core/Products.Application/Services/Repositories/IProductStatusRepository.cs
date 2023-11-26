using Products.Domain;
using Shared;

namespace Products.Application.Services.Repositories;

public interface IProductStatusRepository: IAsyncRepository<ProductStatus, Guid>
{
    
}