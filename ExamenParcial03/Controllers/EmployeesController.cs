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
    public class EmployeesController : Controller
    {
        private readonly HResourceContext _context;

        public EmployeesController(HResourceContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString)
        {
            var _employees = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .Include(e => e.JobHistories)
                    .ThenInclude(e => e.Job)
                .AsNoTracking();
            
            var employees = from e in _employees select e;
            if(!string.IsNullOrEmpty(searchString)){
                employees = employees.Where(e => e.LastName.Contains(searchString) 
                || e.FirstName.Contains(searchString));
            }

            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle");
            PopulateDepartmentsDropDownList();
            PopulateJobsDropDownList();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,CommissionPCT,DepartmentID,JobID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle", employee.JobID);
            PopulateDepartmentsDropDownList();
            PopulateJobsDropDownList();
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle", employee.JobID);
            PopulateDepartmentsDropDownList(id);
            PopulateJobsDropDownList(id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,CommissionPCT,DepartmentID,JobID")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
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
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle", employee.JobID);
            PopulateDepartmentsDropDownList(id);
            PopulateJobsDropDownList(id);
            return View(employee);
        }

        //Llenar un ViewBag Departments
        private void PopulateDepartmentsDropDownList(object selectedDepartment=null){
            var departmentsQuery = from d in _context.Departments
                        orderby d.DepartmentName
                        select d;
            
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(),"DepartmentID","DepartmentName",selectedDepartment);
        }

        //Llenar un ViewBag Jobs
        private void PopulateJobsDropDownList(object selectedJob=null){
            var jobsQuery = from j in _context.Jobs
                        orderby j.JobTitle
                        select j;
            
            ViewBag.JobID = new SelectList(jobsQuery.AsNoTracking(),"JobID","JobTitle",selectedJob);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
