using BusinessApp.Shared.Domain.Models.Commons;

namespace Products.Domain;

public class ProductCardType : BaseEntity 
{
    public string ProductCardTypeCode { get; set; }
    public string ProductCardTypeName { get; set; }
    public string? ProductCardTypeDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}