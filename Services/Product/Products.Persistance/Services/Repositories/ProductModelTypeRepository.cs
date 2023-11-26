using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;
using Shared;

namespace Products.Persistance.Services.Repositories;

public class ProductModelTypeRepository : EfAsyncRepository<ProductModelType, Guid, ProductContext>, IProductModelTypeRepository
{
    public ProductModelTypeRepository(ProductContext context) : base(context)
    {
    }
}