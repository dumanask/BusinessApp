using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;

namespace ProductService.Domain.ProductCommercial;

public class ProducAccountingInformation : ProductProperty
{
    public Guid TaxGroupId { get; set; }
    public Guid AccountingGroupId { get; set; }
    public Guid? DiscountGroupId{ get; set; }
}
