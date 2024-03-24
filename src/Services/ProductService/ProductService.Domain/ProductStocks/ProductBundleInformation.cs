using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductStocks
{
    public class ProductBundleInformation : ProductProperty
    {
        //TODO Think about property and namespace
        public Guid ProductBillOfMeterialId { get; set; }
    }
}
