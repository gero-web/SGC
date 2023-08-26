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
    public class LocalityPrefixesController : Controller
    {
        private readonly EFContext _context;

        public LocalityPrefixesController(EFContext context)
        {
            _context = context;
        }

        // GET: LocalityPrefixes
        public async Task<IActionResult> Index()
        {
              return _context.LocalityPrefix != null ? 
                          View(await _context.LocalityPrefix.ToListAsync()) :
                          Problem("Entity set 'EFContext.LocalityPrefix'  is null.");
        }

        // GET: LocalityPrefixes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocalityPrefix == null)
            {
                return NotFound();
            }

            var localityPrefix = await _context.LocalityPrefix
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localityPrefix == null)
            {
                return NotFound();
            }

            return View(localityPrefix);
        }

        // GET: LocalityPrefixes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalityPrefixes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortName,Name")] LocalityPrefix localityPrefix)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localityPrefix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localityPrefix);
        }

        // GET: LocalityPrefixes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocalityPrefix == null)
            {
                return NotFound();
            }

            var localityPrefix = await _context.LocalityPrefix.FindAsync(id);
            if (localityPrefix == null)
            {
                return NotFound();
            }
            return View(localityPrefix);
        }

        // POST: LocalityPrefixes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShortName,Name")] LocalityPrefix localityPrefix)
        {
            if (id != localityPrefix.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localityPrefix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalityPrefixExists(localityPrefix.Id))
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
            return View(localityPrefix);
        }

        // GET: LocalityPrefixes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocalityPrefix == null)
            {
                return NotFound();
            }

            var localityPrefix = await _context.LocalityPrefix
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localityPrefix == null)
            {
                return NotFound();
            }

            return View(localityPrefix);
        }

        // POST: LocalityPrefixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LocalityPrefix == null)
            {
                return Problem("Entity set 'EFContext.LocalityPrefix'  is null.");
            }
            var localityPrefix = await _context.LocalityPrefix.FindAsync(id);
            if (localityPrefix != null)
            {
                _context.LocalityPrefix.Remove(localityPrefix);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalityPrefixExists(int id)
        {
          return (_context.LocalityPrefix?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
