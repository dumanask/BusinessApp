using Shared;

namespace Products.Domain;

public class ProductCardType : BaseEntity<Guid>
{
    public string ProductCardTypeCode { get; set; }
    public string ProductCardTypeName { get; set; }
    public string? ProductCardTypeDescription { get; set; }
}