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

        DbSet<Bike> Bikes { get; set; }
        DbSet<BikePart> BikeParts { get; set;}
    }
}