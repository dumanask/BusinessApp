using CorePackages.Persistance.Domain;
using ProductService.Domain.ProductBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductDetails
{
    public class ProductOwnershipOption : ProductProperty
    {
        //TODO - Naming will be fixed. Please!!!!!
        public bool Fixture { get; set; }
        public bool Inventory { get; set; }
        public bool IsArrived { get; set; }
        public bool Consigment { get; set; }
        public bool Income { get; set; }
        public bool Expense { get; set; }
        public bool Informative { get; set; }
        public bool Entrusted { get; set; }
    }
}
