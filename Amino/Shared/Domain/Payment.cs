using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amino.Shared.Domain
{
    public class Payment: BaseDomainModel
    {
        public string PayMethod { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
