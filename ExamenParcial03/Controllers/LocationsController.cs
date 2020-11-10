using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HumanResourcesAGC.Data;
using HumanResourcesAGC.Models;

namespace HumanResourcesAGC.Controllers
{
    public class LocationsController : Controller
    {
        private readonly HResourceContext _context;

        public LocationsController(HResourceContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index(string searchString)
        {
            var _locations = _context.Locations
            .Include(l => l.Country)
            .Include(l => l.Departments)
            .AsNoTracking();
            
            var locations = from l in _locations select l;
            if(!string.IsNullOrEmpty(searchString)){
                locations = locations.Where(l => l.StateProvince.Contains(searchString));
            }
            
            return View(await locations.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.Country)
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            //ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName");
            PopulateCountriesDropDownList();
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,StreetAddress,PostalCode,City,StateProvince,CountryID")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", location.CountryID);
            PopulateCountriesDropDownList();
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            //ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", location.CountryID);
            PopulateCountriesDropDownList(id);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,StreetAddress,PostalCode,City,StateProvince,CountryID")] Location location)
        {
            if (id != location.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationID))
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
            //ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", location.CountryID);
            PopulateCountriesDropDownList(id);
            return View(location);
        }

        //Llenar un ViewBag
        private void PopulateCountriesDropDownList(object selectedCountry=null){
            var countriesQuery = from c in _context.Countries
                        orderby c.CountryName
                        select c;
            
            ViewBag.CountryID = new SelectList(countriesQuery.AsNoTracking(),"CountryID","CountryName",selectedCountry);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.Country)
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationID == id);
        }
    }
}
