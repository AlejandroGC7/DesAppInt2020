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
    public class CountriesController : Controller
    {
        private readonly HResourceContext _context;

        public CountriesController(HResourceContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index(string searchString)
        {
            var _countries = _context.Countries
                .Include(c => c.Region)
                .Include(c => c.Locations)
                .AsNoTracking();

            var countries = from c in _countries select c;
            if(!string.IsNullOrEmpty(searchString)){
                countries = countries.Where(c => c.CountryName.Contains(searchString));
            }

            return View(await countries.ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.Region)
                .FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            //ViewData["RegionID"] = new SelectList(_context.Regions, "RegionID", "RegionName");
            PopulateRegionsDropDownList();
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryID,ISO,CountryName,RegionID")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RegionID"] = new SelectList(_context.Regions, "RegionID", "RegionName", country.RegionID);
            PopulateRegionsDropDownList();
            return View(country);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            //ViewData["RegionID"] = new SelectList(_context.Regions, "RegionID", "RegionName", country.RegionID);
            PopulateRegionsDropDownList(id);
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryID,ISO,CountryName,RegionID")] Country country)
        {
            if (id != country.CountryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryID))
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
            //ViewData["RegionID"] = new SelectList(_context.Regions, "RegionID", "RegionName", country.RegionID);
            PopulateRegionsDropDownList(id);
            return View(country);
        }

        //Llenar un ViewBag
        private void PopulateRegionsDropDownList(object selectedRegion=null){
            var regionsQuery = from r in _context.Regions
                        orderby r.RegionName
                        select r;
            
            ViewBag.RegionID = new SelectList(regionsQuery.AsNoTracking(),"RegionID","RegionName",selectedRegion);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .Include(c => c.Region)
                .FirstOrDefaultAsync(m => m.CountryID == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryID == id);
        }
    }
}
