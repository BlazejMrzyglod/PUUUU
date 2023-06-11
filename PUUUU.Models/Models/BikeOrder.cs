

using Microsoft.AspNetCore.Identity;

namespace PUUUU.Models.Models
{
    public class BikeOrder
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public virtual IdentityUser User { get; set; }
        public int BikeId { get; set; }
        public virtual Bike Bike { get; set; }
    }
}
