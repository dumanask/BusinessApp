using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;
using Shared;

namespace Products.Persistance.Services.Repositories;

public class ProductStatusRepository : EfAsyncRepository<ProductStatus, Guid, ProductContext>, IProductStatusRepository
{
    public ProductStatusRepository(ProductContext context) : base(context)
    {
    }
}