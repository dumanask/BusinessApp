using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain;
using Shared;

namespace Products.Persistance.Configurations;

public class ProductConfigurations: BaseEntityConfiguration<Product, Guid>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.ProductCode).IsRequired();
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
        //builder.Property(x => x.Price).IsRequired();

        builder.HasIndex(indexExpression: x => x.ProductCode, name: "UK_Product_ProductCode").IsUnique();


    }
}