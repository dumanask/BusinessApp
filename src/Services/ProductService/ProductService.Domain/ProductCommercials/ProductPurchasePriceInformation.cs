using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductCommercials
{
    public class ProductPurchasePriceInformation : ProductProperty
    {
        //TODO Enumaration for Currency
        public decimal Price { get; set; }
        public Guid PurchasePriceListId { get; set; }
        public int Priority { get; set; }
    }
}
