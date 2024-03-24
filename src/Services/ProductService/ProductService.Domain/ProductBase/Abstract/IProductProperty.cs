using CorePackages.Persistance.Domain;

namespace ProductService.Domain.ProductBase.Abstract;

public abstract class ProductProperty : BaseEntity
{
    public Guid ProductId { get; set; }
}
