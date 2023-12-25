using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain
{
    public class ProductUsageClasses : BaseEntity<Guid>
    {
        public string ProductUsageClassCode { get; set; }
        public string ProductUsageClassName { get; set; }
        public string Description { get; set; }
    }
}
