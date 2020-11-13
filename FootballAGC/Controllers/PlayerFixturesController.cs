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
    public class PlayerFixturesController : Controller
    {
        private readonly FootballContext _context;

        public PlayerFixturesController(FootballContext context)
        {
            _context = context;
        }

        // GET: PlayerFixtures
        public async Task<IActionResult> Index(string searchString)
        {
            var _playerfixtures = _context.PlayerFixtures.Include(p => p.Fixture).Include(p => p.Player);

            var playerfixtures = from pf in _playerfixtures select pf;
            if(!string.IsNullOrEmpty(searchString)){
                playerfixtures = playerfixtures.Where(pf => pf.Player.LastName.Contains(searchString)
                || pf.Player.FirstName.Contains(searchString));
            }
            return View(await playerfixtures.ToListAsync());
        }

        // GET: PlayerFixtures/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var playerFixture = await _context.PlayerFixtures
                .Include(p => p.Fixture)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.FixtureID == id && m.PlayerID == id2);
            if (playerFixture == null)
            {
                return NotFound();
            }

            return View(playerFixture);
        }

        // GET: PlayerFixtures/Create
        public IActionResult Create()
        {
            //ViewData["FixtureID"] = new SelectList(_context.Fixtures, "FixtureID", "FixtureDescription");
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "FullName");
            PopulateFixturesDropDownList();
            //PopulatePlayersDropDownList();
            return View();
        }

        // POST: PlayerFixtures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FixtureID,PlayerID,GoalsScored")] PlayerFixture playerFixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerFixture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["FixtureID"] = new SelectList(_context.Fixtures, "FixtureID", "FixtureDescription", playerFixture.FixtureID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "FullName", playerFixture.PlayerID);
            PopulateFixturesDropDownList();
            //PopulatePlayersDropDownList();
            return View(playerFixture);
        }

        // GET: PlayerFixtures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerFixture = await _context.PlayerFixtures.FindAsync(id);
            if (playerFixture == null)
            {
                return NotFound();
            }
            //ViewData["FixtureID"] = new SelectList(_context.Fixtures, "FixtureID", "FixtureDescription", playerFixture.FixtureID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "FullName", playerFixture.PlayerID);
            PopulateFixturesDropDownList(id);
            //PopulatePlayersDropDownList(id);
            return View(playerFixture);
        }

        // POST: PlayerFixtures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FixtureID,PlayerID,GoalsScored")] PlayerFixture playerFixture)
        {
            if (id != playerFixture.FixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerFixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerFixtureExists(playerFixture.FixtureID))
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
            //ViewData["FixtureID"] = new SelectList(_context.Fixtures, "FixtureID", "FixtureDescription", playerFixture.FixtureID);
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "FullName", playerFixture.PlayerID);
            PopulateFixturesDropDownList(id);
            //PopulatePlayersDropDownList(id);
            return View(playerFixture);
        }

        //Llena ViewBag Fixture
        private void PopulateFixturesDropDownList(object selectedFixture=null){
            var fixturesQuery = from f in _context.Fixtures
                        orderby f.FixtureDescription
                        select f;
            ViewBag.FixtureID = new SelectList(fixturesQuery.AsNoTracking(),"FixtureID","FixtureDescription",selectedFixture);
        }

        //Llena ViewBag Player
        /*private void PopulatePlayersDropDownList(object selectedPlayer=null){
            var playersQuery = from p in _context.Players
                        orderby p.FullName
                        select p;
            ViewBag.PlayerID = new SelectList(playersQuery.AsNoTracking(),"PlayerID","FullName",selectedPlayer);
        }*/

        // GET: PlayerFixtures/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var playerFixture = await _context.PlayerFixtures
                .Include(p => p.Fixture)
                .Include(p => p.Player)
                .FirstOrDefaultAsync(m => m.FixtureID == id && m.PlayerID == id2);
            if (playerFixture == null)
            {
                return NotFound();
            }

            return View(playerFixture);
        }

        // POST: PlayerFixtures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int FixtureID, int PlayerID)
        {
            var playerFixture = await _context.PlayerFixtures.FindAsync(FixtureID,PlayerID);
            _context.PlayerFixtures.Remove(playerFixture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerFixtureExists(int id)
        {
            return _context.PlayerFixtures.Any(e => e.FixtureID == id);
        }
    }
}
