using Bogus;
using BusinessApp.Shared.Application.Encrypts;
using BusinessApp.Shared.Domain.Enums;
using BusinessApp.Shared.Domain.Models.Commons;
using BusinessApp.Shared.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistance.Contexts
{
    internal class SeedData
    {
        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
            var context = new ProductContext(dbContextBuilder.Options);
            if (context.Products.Any())
            {
                await Task.CompletedTask;
                return;
            }

            List<User> users = GetUsers();

            List<ProductCardType> productCardTypes = GetProductCardTypes();
            var productCardTypesIds = GetIds(productCardTypes);

            List<ProductCatalog> prodcutCatalogs = GetProductCatalogs();
            var productCatalogIds = GetIds(prodcutCatalogs);

            List<ProductGroup> productGroups = GetProductGroups();
            var productGroupsIds = GetIds(productGroups);

            List<ProductModelType> productModelTypes = GetProductModelTypes();
            var productModelTypeIds = GetIds(productModelTypes);

            List<ProductStatus> productStatuses = GetProductStatuses();
            var productStatusIds = GetIds(productStatuses);

            List<Product> products = GetProducts(productCardTypesIds,
                                                  productCatalogIds,
                                                  productGroupsIds,
                                                  productModelTypeIds,
                                                  productStatusIds);


            await context.ProductCardTypes.AddRangeAsync(productCardTypes);
            await context.ProductCatalogs.AddRangeAsync(prodcutCatalogs);
            await context.ProductGroups.AddRangeAsync(productGroups);
            await context.ProductModelTypes.AddRangeAsync(productModelTypes);
            await context.ProductStatuses.AddRangeAsync(productStatuses);
            await context.Products.AddRangeAsync(products);

            await context.SaveChangesAsync();
        }
        private IEnumerable<Guid> GetIds<T>(List<T> values)
            where T : BaseEntity
        {
            return values.Select(i => i.Id);
        }

        private List<User> GetUsers()
        {
            var users = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.FirstName, i => i.Person.FirstName)
                .RuleFor(i => i.LastName, i => i.Person.LastName)
                .RuleFor(i => i.Email, i => i.Internet.Email())
                .RuleFor(i => i.Password, i => PasswordEncrypt.Encrypt(i.Internet.Password()))
                .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
                .Generate(250);


            return users;
        }

        private List<ProductCardType> GetProductCardTypes()
        {
            var productCardTypes = new Faker<ProductCardType>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.ProductCardTypeCode, i => i.Name.Random.ClampString("P", 4))
                .RuleFor(i => i.ProductCardTypeDescription, i => i.Commerce.ProductDescription())
                .RuleFor(i => i.ProductCardTypeName, i => i.Commerce.Product())
                .Generate(20);

            return productCardTypes;
        }
        private List<ProductCatalog> GetProductCatalogs()
        {
            var prodcutCatalogs = new Faker<ProductCatalog>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.ProductCatalogCode, i => i.Name.Random.ClampString("pc", 4))
                .RuleFor(i => i.ProductCatalogDescription, i => i.Commerce.ProductDescription())
                .RuleFor(i => i.ProductCatalogName, i => i.Lorem.Word())
                .Generate(20);

            return prodcutCatalogs;
        }
        private List<ProductGroup> GetProductGroups()
        {
            var prodcutGroups = new Faker<ProductGroup>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.ProductGroupCode, i => i.Name.Random.ClampString("pg", 4))
                .RuleFor(i => i.ProductGroupDescription, i => i.Commerce.ProductDescription())
                .RuleFor(i => i.ProductGroupName, i => i.Commerce.ProductName())
                .Generate(20);

            return prodcutGroups;
        }
        private List<ProductModelType> GetProductModelTypes()
        {
            var prodcutGroups = new Faker<ProductModelType>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
                .RuleFor(i => i.ProductModelCode, i => i.Name.Random.ClampString("pm", 4))
                .RuleFor(i => i.ProductModelDescription, i => i.Lorem.Sentence(4))
                .RuleFor(i => i.ProductModelName, i => i.Lorem.Word())
                .Generate(20);

            return prodcutGroups;
        }

        private List<ProductStatus> GetProductStatuses()
        {
            var productStatuses = new Faker<ProductStatus>("tr")
              .RuleFor(i => i.Id, i => Guid.NewGuid())
              .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
              .RuleFor(i => i.ProductStatusCode, i => i.Name.Random.ClampString("ps", 4))
              .RuleFor(i => i.ProductStatusDescription, i => i.Lorem.Sentence(4))
              .RuleFor(i => i.ProductStatusName, i => i.Lorem.Word())
              .Generate(20);

            return productStatuses;
        }
        private List<Product> GetProducts(IEnumerable<Guid> productCardTypeIds,
                                       IEnumerable<Guid> productCatalogIds,
                                       IEnumerable<Guid> prdocutGroupIds,
                                       IEnumerable<Guid> productModelTypeIds,
                                       IEnumerable<Guid> productStatusIds)
        {
            var productStatuses = new Faker<Product>("tr")
              .RuleFor(i => i.Id, i => Guid.NewGuid())
              .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-365), DateTime.Now))
              .RuleFor(i => i.ProductCardTypeId, i => i.PickRandom(productCardTypeIds))
              .RuleFor(i => i.ProductCatalogId, i => i.PickRandom(productCatalogIds))
              .RuleFor(i => i.ProductGroupId, i => i.PickRandom(prdocutGroupIds))
              .RuleFor(i => i.ProductModelTypeId, i => i.PickRandom(productModelTypeIds))
              .RuleFor(i => i.ProductStatusId, i => i.PickRandom(productStatusIds))
              .RuleFor(i => i.ProductCode, i => i.Name.Random.ClampString("P", 4))
              .RuleFor(i => i.Description, i => i.Commerce.ProductDescription())
              .RuleFor(i => i.ProductName, i => i.Commerce.Product())
              .RuleFor(i => i.UnitType, i => i.PickRandom(UnitType.kilogram,UnitType.meter))
              .Generate(200);

            return productStatuses;
        }
    }
}
