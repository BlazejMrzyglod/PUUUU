using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUUUU.Data;

namespace PUUUU.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult BikeOrders()
        {
            return _context.BikeOrders != null ?
                       View(_context.BikeOrders.ToListAsync().Result) :
                       Problem("Entity set 'ApplicationDbContext.Bikes'  is null.");
        }
        public IActionResult ConfigureOrders()
        {
            return _context.ConfigureOrders != null ?
                      View(_context.ConfigureOrders.ToListAsync().Result) :
                      Problem("Entity set 'ApplicationDbContext.Bikes'  is null.");
        }
    }
}
