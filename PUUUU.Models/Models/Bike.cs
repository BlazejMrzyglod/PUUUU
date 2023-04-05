using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public virtual int BikeOfferId { get; set; }
        public virtual BikeOffer BikeOffer { get; set; }
    }
}
