using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductDetails
{
    public class ProductParameter : ProductProperty
    {
        public bool IsSaleble { get; set; }
        public bool IsPurchasable { get; set; }
        public bool IsProducible { get; set; }
        public bool IsServiceEnable { get; set; }
        public bool IsRemoveable { get; set; }
        public bool IsMeasureable { get; set; }
        public bool BeIncludedInCost { get; set; }



    }
}
