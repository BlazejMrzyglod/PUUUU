using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.Models
{
    public class ConfigureOrder
    {
        public int Id { get; set; }
        [DisplayName("Data stworzenia")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Adres")]
        public string Address { get; set; }
        [DisplayName("Metoda płatności")]
        public string PaymentMethod { get; set; }
        [DisplayName("Sposób dostawy")]
        public string DeliveryMethod { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual ICollection<BikePart> Parts { get; set; }
    }
}
