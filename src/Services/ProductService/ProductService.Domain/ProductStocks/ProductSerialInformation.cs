using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductStocks
{
    public class ProductSerialInformation : ProductProperty
    {
        public Guid SerialStatusId { get; set; }
        public Guid SerialTemplateId { get; set; }
        public string SerialCode { get; set; }
    }
}
