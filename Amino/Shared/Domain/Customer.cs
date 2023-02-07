using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amino.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
