using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amino.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
