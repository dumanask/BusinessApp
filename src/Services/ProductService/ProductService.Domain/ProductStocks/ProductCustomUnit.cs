using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;

namespace ProductService.Domain.ProductStocks;

public class ProductCustomUnit : ProductProperty
{
    public string Name { get; set; }
    public double Value { get; set; }
    public double IncludedProductCount { get; set; }
    public double TotalInclude => Calculate();
    private double Calculate() => (double)(Value * IncludedProductCount);
    //TODO Add Specific Calculation using Global measure units
}
