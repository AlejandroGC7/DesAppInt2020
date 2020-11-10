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
    public class DepartmentsController : Controller
    {
        private readonly HResourceContext _context;

        public DepartmentsController(HResourceContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index(string searchString)
        {
            var _departments = _context.Departments
                .Include(d => d.Location)
                .Include(d => d.Employees)
                .AsNoTracking();
            
            var departments = from d in _departments select d;
            if(!string.IsNullOrEmpty(searchString)){
                departments = departments.Where(d => d.DepartmentName.Contains(searchString));
            }
            
            return View(await departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Location)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "City");
            PopulateLocationsDropDownList();
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,DepartmentName,LocationID")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "City", department.LocationID);
            PopulateLocationsDropDownList();
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "City", department.LocationID);
            PopulateLocationsDropDownList(id);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,DepartmentName,LocationID")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentID))
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
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "City", department.LocationID);
            PopulateLocationsDropDownList(id);
            return View(department);
        }

        //Llenar un ViewBag
        private void PopulateLocationsDropDownList(object selectedLocation=null){
            var locationsQuery = from l in _context.Locations
                        orderby l.City
                        select l;
            
            ViewBag.LocationID = new SelectList(locationsQuery.AsNoTracking(),"LocationID","City",selectedLocation);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Location)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }
    }
}
