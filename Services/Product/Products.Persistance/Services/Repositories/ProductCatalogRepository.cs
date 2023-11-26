using Products.Application.Services.Repositories;
using Products.Domain;
using Products.Persistance.Contexts;
using Shared;

namespace Products.Persistance.Services.Repositories;

public class ProductCatalogRepository : EfAsyncRepository<ProductCatalog, Guid, ProductContext>, IProductCatalogRepository
{
    public ProductCatalogRepository(ProductContext context) : base(context)
    {
    }
}