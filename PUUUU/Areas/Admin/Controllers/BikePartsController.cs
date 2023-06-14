using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUUUU.Data;
using PUUUU.Models.Models;

namespace PUUUU.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class BikePartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BikePartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BikeParts
        public async Task<IActionResult> Index()
        {
            return _context.BikeParts != null ?
                        View(await _context.BikeParts.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.BikeParts'  is null.");
        }

        // GET: BikeParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BikeParts == null)
            {
                return NotFound();
            }

            var bikePart = await _context.BikeParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikePart == null)
            {
                return NotFound();
            }

            return View(bikePart);
        }

        // GET: BikeParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikeParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,Price,Quantity")] BikePart bikePart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikePart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikePart);
        }

        // GET: BikeParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BikeParts == null)
            {
                return NotFound();
            }

            var bikePart = await _context.BikeParts.FindAsync(id);
            if (bikePart == null)
            {
                return NotFound();
            }
            return View(bikePart);
        }

        // POST: BikeParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,Price,Quantity")] BikePart bikePart)
        {
            if (id != bikePart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikePart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikePartExists(bikePart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bikePart);
        }

        // GET: BikeParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BikeParts == null)
            {
                return NotFound();
            }

            var bikePart = await _context.BikeParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikePart == null)
            {
                return NotFound();
            }

            return View(bikePart);
        }

        // POST: BikeParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BikeParts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BikeParts'  is null.");
            }
            var bikePart = await _context.BikeParts.FindAsync(id);
            if (bikePart != null)
            {
                _context.BikeParts.Remove(bikePart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikePartExists(int id)
        {
            return (_context.BikeParts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
