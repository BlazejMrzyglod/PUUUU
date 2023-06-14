

using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace PUUUU.Models.Models
{
    public class BikeOrder
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
        public int BikeId { get; set; }
        public virtual Bike Bike { get; set; }
    }
}
