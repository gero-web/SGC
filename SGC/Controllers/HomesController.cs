using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGC.Models;
using SGC.db;
using Microsoft.IdentityModel.Tokens;

namespace SGC.Controllers
{
    public class HomesController : Controller
    {
        private readonly EFContext _context;

        public HomesController(EFContext context)
        {
            _context = context;
        }

        // GET: Homes
        public async Task<IActionResult> Index(string? street, int? countApartaments, string? home, string? locality)
        {
            var eFContext = _context.Homes.Include(h => h.Street)
                .ThenInclude(h => h.Locality)
                .ThenInclude(h => h.LocalityPrefix)
                .Include(h => h.Street)
                .ThenInclude(h => h.StreetPrefix)
                .OrderBy(s => s.Street.Locality.Name)
                .ThenBy(s => s.CountApartments)
                .ThenBy(s => s.Name);


            var homeList = await eFContext.ToListAsync();
            var Localities = await _context.Locality.ToListAsync();
            var streets = await _context.Streets.Where(x => locality.IsNullOrEmpty() || x.Locality.Name.Equals(locality)  ).ToListAsync();
            homeList = homeList.Where(x => (locality.IsNullOrEmpty() || x.Street.Locality.Name.Equals(locality)) &&
                                        (street.IsNullOrEmpty() || x.Street.Name.Equals(street) &&
                                        (countApartaments == null || countApartaments < 0 || x.CountApartments == countApartaments) && 
                                        ( home.IsNullOrEmpty() || x.Equals(home))
                                 )).ToList();
            
            ViewData["Homes"] = new SelectList(homeList, selectedValue: null);
            ViewData["Localities"] = new SelectList(Localities, selectedValue: null);
            ViewData["streets"] = new SelectList(streets, selectedValue: null);

           
                 
            
 
            return View(homeList);
        }

        // GET: Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Homes == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Street)
                .ThenInclude(h => h.Locality)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (home == null)
            {
                return NotFound();
            }

            IList<Apartment> apartments = await _context.Apartments.Where( apartment => apartment.Home.Id == id).ToListAsync();
            ViewBag.apartments = apartments;
          

            return View(home);
        }

        // GET: Homes/Create
        public IActionResult Create()
        {
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Name");
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StreetId,CountApartments")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Name", home.StreetId);
            return View(home);
        }

        // GET: Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Homes == null)
            {
                return NotFound();
            }

            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Name", home.StreetId);
            return View(home);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StreetId,CountApartments")] Home home)
        {
            if (id != home.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.Id))
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
            ViewData["StreetId"] = new SelectList(_context.Streets, "Id", "Name", home.StreetId);
            return View(home);
        }

        // GET: Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Homes == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Street)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Homes == null)
            {
                return Problem("Entity set 'EFContext.Homes'  is null.");
            }
            var home = await _context.Homes.FindAsync(id);
            if (home != null)
            {
                _context.Homes.Remove(home);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(int id)
        {
          return (_context.Homes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
