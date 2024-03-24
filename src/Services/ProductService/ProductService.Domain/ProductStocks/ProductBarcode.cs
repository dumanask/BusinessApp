using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductStocks
{
    public class ProductBarcode : ProductProperty
    {
        //TODO -- should Status Id changed or not?
        public Guid BarcodeTemplateId { get; set; }
        public Guid StatusId { get; set; }
        public string Code { get; set; }
    }
}
