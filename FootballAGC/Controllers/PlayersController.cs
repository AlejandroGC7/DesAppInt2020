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
    public class PlayersController : Controller
    {
        private readonly FootballContext _context;

        public PlayersController(FootballContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index(string searchString)
        {
            var _players = _context.Players
                .Include(p => p.Selection)
                .Include(p => p.Team)
                .Include(p => p.PlayerPosition)
                .Include(p => p.PlayerFixtures)
                    .ThenInclude(p => p.Fixture)
                        .ThenInclude(p => p.Competition)
                .AsNoTracking();

            var players = from p in _players select p;
            if(!string.IsNullOrEmpty(searchString)){
                players = players.Where(p => p.LastName.Contains(searchString)
                || p.FirstName.Contains(searchString));
            }
            return View(await players.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Selection)
                .Include(p => p.Team)
                .Include(p => p.PlayerPosition)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            //ViewData["SelectionID"] = new SelectList(_context.Selections, "SelectionID", "SelectionName");
            //ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName");
            //ViewData["PositionID"] = new SelectList(_context.PlayerPositions, "PositionID", "PositionDescription");
            PopulateTeamsDropDownList();
            PopulateSelectionsDropDownList();
            PopulatePlayerPositionsDropDownList();
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerID,TeamID,SelectionID,FirstName,LastName,PlayerSquadNumber,PlayerBirthdate,PlayerNationality,PlayerValue,PlayerPositionID")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["SelectionID"] = new SelectList(_context.Selections, "SelectionID", "SelectionName", player.SelectionID);
            //ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", player.TeamID);
            //ViewData["PositionID"] = new SelectList(_context.PlayerPositions, "PositionID", "PositionDescription");
            PopulateTeamsDropDownList();
            PopulateSelectionsDropDownList();
            PopulatePlayerPositionsDropDownList();
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            //ViewData["SelectionID"] = new SelectList(_context.Selections, "SelectionID", "SelectionName", player.SelectionID);
            //ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", player.TeamID);
            //ViewData["PositionID"] = new SelectList(_context.PlayerPositions, "PositionID", "PositionDescription");
            PopulateTeamsDropDownList(id);
            PopulateSelectionsDropDownList(id);
            PopulatePlayerPositionsDropDownList(id);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerID,TeamID,SelectionID,FirstName,LastName,PlayerSquadNumber,PlayerBirthdate,PlayerNationality,PlayerValue,PlayerPositionID")] Player player)
        {
            if (id != player.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.PlayerID))
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
            //ViewData["SelectionID"] = new SelectList(_context.Selections, "SelectionID", "SelectionName", player.SelectionID);
            //ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamName", player.TeamID);
            //ViewData["PositionID"] = new SelectList(_context.PlayerPositions, "PositionID", "PositionDescription");
            PopulateTeamsDropDownList(id);
            PopulateSelectionsDropDownList(id);
            PopulatePlayerPositionsDropDownList(id);
            return View(player);
        }

        //Llena ViewBag Team
        private void PopulateTeamsDropDownList(object selectedTeam=null){
            var teamsQuery = from t in _context.Teams
                        orderby t.TeamName
                        select t;
            ViewBag.TeamID = new SelectList(teamsQuery.AsNoTracking(),"TeamID","TeamName",selectedTeam);
        }

        //Llena ViewBag Selection
        private void PopulateSelectionsDropDownList(object selectedSelection=null){
            var selectionsQuery = from s in _context.Selections
                        orderby s.SelectionName
                        select s;
            ViewBag.SelectionID = new SelectList(selectionsQuery.AsNoTracking(),"SelectionID","SelectionName",selectedSelection);
        }

        //Llena ViewBag Position
        private void PopulatePlayerPositionsDropDownList(object selectedPlayerPosition=null){
            var playerpositionsQuery = from pp in _context.PlayerPositions
                        orderby pp.PositionDescription
                        select pp;
            ViewBag.PlayerPositionID = new SelectList(playerpositionsQuery.AsNoTracking(),"PlayerPositionID","PositionDescription",selectedPlayerPosition);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Selection)
                .Include(p => p.Team)
                .Include(p => p.PlayerPosition)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerID == id);
        }
    }
}
