using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.Models
{
    public class BikeOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public virtual int BikeId { get; set; }
        public virtual Bike Bike { get; set; }
    }
}
