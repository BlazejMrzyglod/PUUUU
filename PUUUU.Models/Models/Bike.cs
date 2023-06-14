using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.Models
{
    public class Bike
    {
        public int Id { get; set; }
        [DisplayName("Marka")]
        public string Brand { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }
        [DisplayName("Rozmiar")]
        public string Size { get; set; }
        [DisplayName("Cena")]
        public double Price { get; set; }
        [DisplayName("Ilość dostępnych")]
        public int Quantity { get; set; }
        public string Image { get; set; }
        public virtual ICollection<BikeOrder>? Orders { get; set; }
        //public virtual ICollection<BikePart> BikeParts { get; set; }
    }
}
