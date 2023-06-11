using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.Models
{
    public class ConfigureOrder
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual ICollection<BikePart> Parts { get; set; }
    }
}
