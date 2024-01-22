using BusinessApp.Shared.Persistance.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain;

namespace Products.Persistance.Configurations;

public class ProductConfigurations : BaseEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.ProductCode).IsRequired();
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.UnitType).IsRequired();



        builder.HasOne(x => x.ProductCardType)
       .WithMany(x => x.Products)
       .HasForeignKey(x => x.ProductCardTypeId);

        builder.HasOne(x => x.ProductModelType)
       .WithMany(x => x.Products)
       .HasForeignKey(x => x.ProductModelTypeId);

        builder.HasOne(x => x.ProductGroup)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.ProductGroupId);

        builder.HasOne(x => x.ProductStatus)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.ProductStatusId);

        builder.HasOne(x => x.ProductCatalog)
             .WithMany(x => x.Products)
             .HasForeignKey(x => x.ProductCatalogId);

    }
}