using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductCommercials
{
    public class ProductSalesPriceInformation : ProductProperty
    {
        //TODO Create Enumaration for Currency
        public Guid? SalesPriceListId { get; set; }
        public decimal Price { get; set; }
        public int HasPriority { get; set; }

    }
}
