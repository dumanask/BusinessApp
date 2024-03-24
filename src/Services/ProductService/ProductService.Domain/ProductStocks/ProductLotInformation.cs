using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductStocks
{
    public class ProductLotInformation : ProductProperty
    {
        public Guid LotTemplateId { get; set; }
        public string LotCode { get; set; }
        public Guid LotStatusId { get; set; }
        public DateTime LotProductionDate { get; set; }
        public DateTime ExpirityDate { get; set; }

    }
}
