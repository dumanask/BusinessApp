using CorePackages.Persistance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ProductBase
{
    public class Product : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
