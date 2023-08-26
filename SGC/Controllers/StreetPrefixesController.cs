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
    public class StreetPrefixesController : Controller
    {
        private readonly EFContext _context;

        public StreetPrefixesController(EFContext context)
        {
            _context = context;
        }

        // GET: StreetPrefixes
        public async Task<IActionResult> Index()
        {
              return _context.StreetPrefixes != null ? 
                          View(await _context.StreetPrefixes.ToListAsync()) :
                          Problem("Entity set 'EFContext.StreetPrefixes'  is null.");
        }

        // GET: StreetPrefixes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StreetPrefixes == null)
            {
                return NotFound();
            }

            var streetPrefix = await _context.StreetPrefixes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (streetPrefix == null)
            {
                return NotFound();
            }

            return View(streetPrefix);
        }

        // GET: StreetPrefixes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StreetPrefixes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortName,Name")] StreetPrefix streetPrefix)
        {
            if (ModelState.IsValid)
            {
                _context.Add(streetPrefix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(streetPrefix);
        }

        // GET: StreetPrefixes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StreetPrefixes == null)
            {
                return NotFound();
            }

            var streetPrefix = await _context.StreetPrefixes.FindAsync(id);
            if (streetPrefix == null)
            {
                return NotFound();
            }
            return View(streetPrefix);
        }

        // POST: StreetPrefixes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShortName,Name")] StreetPrefix streetPrefix)
        {
            if (id != streetPrefix.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(streetPrefix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetPrefixExists(streetPrefix.Id))
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
            return View(streetPrefix);
        }

        // GET: StreetPrefixes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StreetPrefixes == null)
            {
                return NotFound();
            }

            var streetPrefix = await _context.StreetPrefixes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (streetPrefix == null)
            {
                return NotFound();
            }

            return View(streetPrefix);
        }

        // POST: StreetPrefixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StreetPrefixes == null)
            {
                return Problem("Entity set 'EFContext.StreetPrefixes'  is null.");
            }
            var streetPrefix = await _context.StreetPrefixes.FindAsync(id);
            if (streetPrefix != null)
            {
                _context.StreetPrefixes.Remove(streetPrefix);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetPrefixExists(int id)
        {
          return (_context.StreetPrefixes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
