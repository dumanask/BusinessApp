using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductStocks
{
    public class ProductGuaranteeInformation : ProductProperty
    {
        public Guid GuaranteeProfileId { get; set; }
        public Guid ExpirationProfileId { get; set; }

    }
}
