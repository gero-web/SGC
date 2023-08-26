using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGC.Models;
using SGC.db;

namespace SGC.Controllers
{
    public class StreetsController : Controller
    {
        private readonly EFContext _context;

        public StreetsController(EFContext context)
        {
            _context = context;
        }

        // GET: Streets
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Streets.Include(s => s.Locality).Include(s => s.StreetPrefix);
            return View(await eFContext.ToListAsync());
        }

        // GET: Streets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Streets == null)
            {
                return NotFound();
            }

            var street = await _context.Streets
                .Include(s => s.Locality)
                .Include(s => s.StreetPrefix)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        // GET: Streets/Create
        public IActionResult Create()
        {
            ViewData["LocalityId"] = new SelectList(_context.Locality, "Id", "Name");
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "Id", "Name");
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LocalityId,StreetPrefixId")] Street street)
        {
            if (ModelState.IsValid)
            {
                _context.Add(street);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalityId"] = new SelectList(_context.Locality, "Id", "Id", street.LocalityId);
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "Id", "Name", street.StreetPrefixId);
            return View(street);
        }

        // GET: Streets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Streets == null)
            {
                return NotFound();
            }

            var street = await _context.Streets.FindAsync(id);
            if (street == null)
            {
                return NotFound();
            }
            ViewData["LocalityId"] = new SelectList(_context.Locality, "Id", "Name", street.LocalityId);
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "Id", "Name", street.StreetPrefixId);
            return View(street);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LocalityId,StreetPrefixId")] Street street)
        {
            if (id != street.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(street);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetExists(street.Id))
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
            ViewData["LocalityId"] = new SelectList(_context.Locality, "Id", "Name", street.LocalityId);
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "Id", "Name", street.StreetPrefixId);
            return View(street);
        }

        // GET: Streets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Streets == null)
            {
                return NotFound();
            }

            var street = await _context.Streets
                .Include(s => s.Locality)
                .Include(s => s.StreetPrefix)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Streets == null)
            {
                return Problem("Entity set 'EFContext.Streets'  is null.");
            }
            var street = await _context.Streets.FindAsync(id);
            if (street != null)
            {
                _context.Streets.Remove(street);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetExists(int id)
        {
          return (_context.Streets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
