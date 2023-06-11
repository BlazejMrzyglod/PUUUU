using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PUUUU.Models.Models;

namespace PUUUU.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {     
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikePart> BikeParts { get; set; }
        public DbSet<BikeOrder> BikeOrders { get; set; }
        public DbSet<ConfigureOrder> ConfigureOrders { get; set; }

    }
}