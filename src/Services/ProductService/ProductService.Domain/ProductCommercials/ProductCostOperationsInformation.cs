using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductCommercials
{
    public class ProductCostOperationsInformation : ProductProperty
    {
        public Guid CostAnalysisTemplateId { get; set; }
    }
}
