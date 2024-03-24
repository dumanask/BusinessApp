using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;

namespace ProductService.Domain.ProductDescriptions;

public class ProductCharacterization : ProductProperty
{
    public Guid CategoryId { get; set; }
    public Guid ProductTypeId { get; set; }
    public Guid UsageClassId { get; set; }
    public Guid? ProductModelTypeId { get; set; }
    public Guid? ProductGroupId{ get; set; }

}
