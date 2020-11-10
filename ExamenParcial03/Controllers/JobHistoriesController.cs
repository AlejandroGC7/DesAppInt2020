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
    public class JobHistoriesController : Controller
    {
        private readonly HResourceContext _context;

        public JobHistoriesController(HResourceContext context)
        {
            _context = context;
        }

        // GET: JobHistories
        public async Task<IActionResult> Index(string searchString)
        {
            var _jobhistories = _context.JobHistories.Include(j => j.Department).Include(j => j.Employee).Include(j => j.Job);
            
            var jobhistories = from jh in _jobhistories select jh;
            if(!string.IsNullOrEmpty(searchString)){
                jobhistories = jobhistories.Where(jh => jh.Employee.FirstName.Contains(searchString)
                || jh.Employee.LastName.Contains(searchString));
            }

            return View(await jobhistories.ToListAsync());
        }

        // GET: JobHistories/Details/5
        public async Task<IActionResult> Details(int? id, int? id2, int? id3)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistories
                .Include(j => j.Department)
                .Include(j => j.Employee)
                .Include(j => j.Job)
                .FirstOrDefaultAsync(m => m.EmployeeID == id && m.JobID == id2 && m.DepartmentID == id3);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // GET: JobHistories/Create
        public IActionResult Create()
        {
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FullName");
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle");
            PopulateDepartmentsDropDownList();
            //PopulateEmployeesDropDownList();
            PopulateJobsDropDownList();
            return View();
        }

        // POST: JobHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,JobID,DepartmentID,StartDate,EndDate")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", jobHistory.DepartmentID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FullName", jobHistory.EmployeeID);
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle", jobHistory.JobID);
            PopulateDepartmentsDropDownList();
            //PopulateEmployeesDropDownList();
            PopulateJobsDropDownList();
            return View(jobHistory);
        }

        // GET: JobHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistories.FindAsync(id);
            if (jobHistory == null)
            {
                return NotFound();
            }
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", jobHistory.DepartmentID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FullName", jobHistory.EmployeeID);
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle", jobHistory.JobID);
            PopulateDepartmentsDropDownList(id);
            //PopulateEmployeesDropDownList(id);
            PopulateJobsDropDownList(id);
            return View(jobHistory);
        }

        // POST: JobHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,JobID,DepartmentID,StartDate,EndDate")] JobHistory jobHistory)
        {
            if (id != jobHistory.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobHistoryExists(jobHistory.EmployeeID))
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
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", jobHistory.DepartmentID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FullName", jobHistory.EmployeeID);
            //ViewData["JobID"] = new SelectList(_context.Jobs, "JobID", "JobTitle", jobHistory.JobID);
            PopulateDepartmentsDropDownList(id);
            //PopulateEmployeesDropDownList(id);
            PopulateJobsDropDownList(id);
            return View(jobHistory);
        }

        //Llenar un ViewBag Employees
        /*private void PopulateEmployeesDropDownList(object selectedEmployee=null){
            var employeesQuery = from e in _context.Employees
                        orderby e.FullName
                        select e;
            
            ViewBag.EmployeeID = new SelectList(employeesQuery.AsNoTracking(),"EmployeeID","FullName",selectedEmployee);
        }*/

        //Llenar un ViewBag Jobs
        private void PopulateJobsDropDownList(object selectedJob=null){
            var jobsQuery = from j in _context.Jobs
                        orderby j.JobTitle
                        select j;
            
            ViewBag.JobID = new SelectList(jobsQuery.AsNoTracking(),"JobID","JobTitle",selectedJob);
        }

        //Llenar un ViewBag Departments
        private void PopulateDepartmentsDropDownList(object selectedDepartment=null){
            var departmentsQuery = from d in _context.Departments
                        orderby d.DepartmentName
                        select d;
            
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(),"DepartmentID","DepartmentName",selectedDepartment);
        }

        // GET: JobHistories/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2, int? id3)
        {
            if (id == null || id2 == null || id3 == null)
            {
                return NotFound();
            }

            var jobHistory = await _context.JobHistories
                .Include(j => j.Department)
                .Include(j => j.Employee)
                .Include(j => j.Job)
                .FirstOrDefaultAsync(m => m.EmployeeID == id && m.JobID == id2 && m.DepartmentID == id3);
            if (jobHistory == null)
            {
                return NotFound();
            }

            return View(jobHistory);
        }

        // POST: JobHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmployeeID, int JobID, int DepartmentID)
        {
            var jobHistory = await _context.JobHistories.FindAsync(EmployeeID,JobID,DepartmentID);
            _context.JobHistories.Remove(jobHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobHistoryExists(int id)
        {
            return _context.JobHistories.Any(e => e.EmployeeID == id);
        }
    }
}
