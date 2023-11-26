using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;
using Shared;

namespace Products.Persistance.Services.Repositories;

public class ProductGroupRepository : EfAsyncRepository<ProductGroup, Guid, ProductContext>, IProductGroupRepository
{
    public ProductGroupRepository(ProductContext context) : base(context)
    {
    }
}