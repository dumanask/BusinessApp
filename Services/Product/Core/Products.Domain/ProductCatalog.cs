using Shared;

namespace Products.Domain;

public class ProductCatalog : BaseEntity<Guid>
{
    public string ProductCatalogCode { get; set; }
    public string ProductCatalogName { get; set; }
    public string? ProductCatalogDescription { get; set; }
}