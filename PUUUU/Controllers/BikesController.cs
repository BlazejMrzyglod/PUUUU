using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUUUU.Data;
using PUUUU.Models.Models;

namespace PUUUU.Controllers
{
    public class BikesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BikesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
            return _context.Bikes != null ?
                        View(await _context.Bikes.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Bikes'  is null.");
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bikes == null)
            {
                return NotFound();
            }

            var bike = await _context.Bikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }


        // GET: Bikes/Order
        [Authorize]
        public IActionResult Order(int id)
        {
            return View();
        }

        // POST: Bikes/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Order(int id, [Bind("Address,PaymentMethod,DeliveryMethod")] BikeOrder order, string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            order.User = user;

            order.CreatedDate = DateTime.Now;
            order.BikeId = id;
            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(int id)
        {
            return (_context.Bikes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
