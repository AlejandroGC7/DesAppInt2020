using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballAGC.Data;
using FootballAGC.Models;

namespace FootballAGC.Controllers
{
    public class FixturesController : Controller
    {
        private readonly FootballContext _context;

        public FixturesController(FootballContext context)
        {
            _context = context;
        }

        // GET: Fixtures
        public async Task<IActionResult> Index(string searchString)
        {
            var _fixtures = _context.Fixtures.Include(f => f.AwayTeam).Include(f => f.Competition).Include(f => f.HomeTeam);

            var fixtures = from f in _fixtures select f;
            if(!string.IsNullOrEmpty(searchString)){
                fixtures = fixtures.Where(f => f.Competition.CompetitionName.Contains(searchString));
            }
            return View(await fixtures.ToListAsync());
        }

        // GET: Fixtures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .Include(f => f.AwayTeam)
                .Include(f => f.Competition)
                .Include(f => f.HomeTeam)
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        // GET: Fixtures/Create
        public IActionResult Create()
        {
            //ViewData["AwayTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName");
            //ViewData["CompetitionID"] = new SelectList(_context.Competitions, "CompetitionID", "CompetitionName");
            //ViewData["HomeTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName");
            PopulateHomeTeamsDropDownList();
            PopulateAwayTeamsDropDownList();
            PopulateCompetitionsDropDownList();
            return View();
        }

        // POST: Fixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureID,FixtureDescription,FixtureDate,FixtureTime,HomeTeamID,AwayTeamID,CompetitionID")] Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AwayTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", fixture.AwayTeamID);
            //ViewData["CompetitionID"] = new SelectList(_context.Competitions, "CompetitionID", "CompetitionName", fixture.CompetitionID);
            //ViewData["HomeTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", fixture.HomeTeamID);
            PopulateHomeTeamsDropDownList();
            PopulateAwayTeamsDropDownList();
            PopulateCompetitionsDropDownList();
            return View(fixture);
        }

        // GET: Fixtures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FindAsync(id);
            if (fixture == null)
            {
                return NotFound();
            }
            //ViewData["AwayTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", fixture.AwayTeamID);
            //ViewData["CompetitionID"] = new SelectList(_context.Competitions, "CompetitionID", "CompetitionName", fixture.CompetitionID);
            //ViewData["HomeTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", fixture.HomeTeamID);
            PopulateHomeTeamsDropDownList(id);
            PopulateAwayTeamsDropDownList(id);
            PopulateCompetitionsDropDownList(id);
            return View(fixture);
        }

        // POST: Fixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FixtureID,FixtureDescription,FixtureDate,FixtureTime,HomeTeamID,AwayTeamID,CompetitionID")] Fixture fixture)
        {
            if (id != fixture.FixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureExists(fixture.FixtureID))
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
            //ViewData["AwayTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", fixture.AwayTeamID);
            //ViewData["CompetitionID"] = new SelectList(_context.Competitions, "CompetitionID", "CompetitionName", fixture.CompetitionID);
            //ViewData["HomeTeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", fixture.HomeTeamID);
            PopulateHomeTeamsDropDownList(id);
            PopulateAwayTeamsDropDownList(id);
            PopulateCompetitionsDropDownList(id);
            return View(fixture);
        }

        //Llena ViewBag HomeTeam
        private void PopulateHomeTeamsDropDownList(object selectedHomeTeam=null){
            var hometeamsQuery = from ht in _context.Teams
                        orderby ht.TeamName
                        select ht;
            ViewBag.HomeTeamID = new SelectList(hometeamsQuery.AsNoTracking(),"TeamID","TeamName",selectedHomeTeam);
        }

        //Llena ViewBag AwayTeam
        private void PopulateAwayTeamsDropDownList(object selectedAwayTeam=null){
            var awayteamsQuery = from at in _context.Teams
                        orderby at.TeamName
                        select at;
            ViewBag.AwayTeamID = new SelectList(awayteamsQuery.AsNoTracking(),"TeamID","TeamName",selectedAwayTeam);
        }

        //Llena ViewBag HomeTeam
        private void PopulateCompetitionsDropDownList(object selectedCompetition=null){
            var competitionsQuery = from c in _context.Competitions
                        orderby c.CompetitionName
                        select c;
            ViewBag.CompetitionID = new SelectList(competitionsQuery.AsNoTracking(),"CompetitionID","CompetitionName",selectedCompetition);
        }

        // GET: Fixtures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures
                .Include(f => f.AwayTeam)
                .Include(f => f.Competition)
                .Include(f => f.HomeTeam)
                .FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }

            return View(fixture);
        }

        // POST: Fixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fixture = await _context.Fixtures.FindAsync(id);
            _context.Fixtures.Remove(fixture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixtureExists(int id)
        {
            return _context.Fixtures.Any(e => e.FixtureID == id);
        }
    }
}
