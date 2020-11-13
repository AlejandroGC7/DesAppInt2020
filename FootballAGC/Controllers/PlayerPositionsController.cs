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
    public class PlayerPositionsController : Controller
    {
        private readonly FootballContext _context;

        public PlayerPositionsController(FootballContext context)
        {
            _context = context;
        }

        // GET: PlayerPositions
        public async Task<IActionResult> Index(string searchString)
        {
            var _playerpositions = _context.PlayerPositions
                .Include(i => i.Players)
                .AsNoTracking();
            
            var playerpositions = from pp in _playerpositions select pp;
            if(!string.IsNullOrEmpty(searchString)){
                playerpositions = playerpositions.Where(pp => pp.PositionDescription.Contains(searchString));
            }
            return View(await playerpositions.ToListAsync());
        }

        // GET: PlayerPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerPosition = await _context.PlayerPositions
                .FirstOrDefaultAsync(m => m.PlayerPositionID==id);
            if (playerPosition == null)
            {
                return NotFound();
            }

            return View(playerPosition);
        }

        // GET: PlayerPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerPositionID,Position,PositionDescription")] PlayerPosition playerPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerPosition);
        }

        // GET: PlayerPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerPosition = await _context.PlayerPositions.FindAsync(id);
            if (playerPosition == null)
            {
                return NotFound();
            }
            return View(playerPosition);
        }

        // POST: PlayerPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionID,Position,PositionDescription")] PlayerPosition playerPosition)
        {
            if (id != playerPosition.PlayerPositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerPositionExists(playerPosition.PlayerPositionID))
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
            return View(playerPosition);
        }

        // GET: PlayerPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerPosition = await _context.PlayerPositions
                .FirstOrDefaultAsync(m => m.PlayerPositionID == id);
            if (playerPosition == null)
            {
                return NotFound();
            }

            return View(playerPosition);
        }

        // POST: PlayerPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerPosition = await _context.PlayerPositions.FindAsync(id);
            _context.PlayerPositions.Remove(playerPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerPositionExists(int id)
        {
            return _context.PlayerPositions.Any(e => e.PlayerPositionID == id);
        }
    }
}
