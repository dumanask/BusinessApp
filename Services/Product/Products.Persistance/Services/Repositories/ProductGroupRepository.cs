using BusinessApp.Shared.Persistance.Repositories;
using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;

namespace Products.Persistance.Services.Repositories;

public class ProductGroupRepository : EfAsyncRepository<ProductGroup, ProductContext>, IProductGroupRepository
{
    public ProductGroupRepository(ProductContext context) : base(context)
    {
    }
}