using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductStocks
{
    public class ProductStockLevelInformation : ProductProperty
    {
        public Guid LevelProfileId { get; set; }
        public double StockLimit { get; set; }

    }
}
