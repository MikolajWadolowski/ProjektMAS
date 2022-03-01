using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektMAS.Data;
using ProjektMAS.Models;

namespace ProjektMAS.Controllers
{
    public class MatchesController : Controller
    {
        private readonly MasContext _context;

        public MatchesController(MasContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var masContext = _context.Matches.Include(m => m.Hall).Include(m => m.Referee).Include(m => m.Team);
            return View(await masContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Hall)
                .Include(m => m.Referee)
                .Include(m => m.Team)
                .FirstOrDefaultAsync(m => m.MatchID == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        
        public IActionResult Create()
        {

            ViewData["MatchHallID"] = new SelectList(_context.Halls, nameof(MatchHall.MatchHallID), nameof(MatchHall.HallName));
            ViewData["TeamID"] = new SelectList(_context.Teams, nameof(Team.TeamID), nameof(Team.TeamName));
            //  ViewBag.Options = new SelectList(_context.Halls, nameof(MatchHall.MatchHallID), nameof(MatchHall.HallName));
            //ViewData["MatchHallID"] = new SelectList(_context.Halls, "MatchHallID", "MatchHallID");
            //  ViewData["PersonID"] = new SelectList(_context.Person, "PersonID", "PersonID");
          //  ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID");
          
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchID,MatchHallID,TeamID,OpponentName,DataSince,DataUntill,Duration,Status,PersonID,isActive,DayofTheMatch")] Match match)
        {

            
            if (match.isActive == true)
            {
                match.Status = Status.ADDINGREFERE;
                System.Diagnostics.Debug.WriteLine("Status jest " + match.Status);
                System.Diagnostics.Debug.WriteLine("Wykonuje przypadek uzycia dodaj sędziego");

                var random = new Random();
                var list = (await _context.Person.ToListAsync());
                var RefereeList = list.FindAll(s => s.PersonType.Equals(PersonType.Referee));
                int index = random.Next(list.Count);
                match.PersonID = list[index].PersonID;
                match.Status = Status.CREATED;
                System.Diagnostics.Debug.WriteLine("Status jest " + match.Status);


            } else {
                match.Status = Status.CREATED;
                match.PersonID = null;
                System.Diagnostics.Debug.WriteLine("Status jest " + match.Status);
            }
           
            string dt = match.DataUntill.Subtract(match.DataSince).ToString().Split('.')[0].ToString();
            match.Duration = dt;
            
            
         

          //  System.Diagnostics.Debug.WriteLine("Wykonuje przypadek uzycia dodaj sędziego");
         //   match.Status = Status.CREATED;
          //  System.Diagnostics.Debug.WriteLine("Status jest " + match.Status);



                    _context.Add(match);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                
            
         
            ViewData["MatchHallID"] = new SelectList(_context.Halls, "MatchHallID", "MatchHallID", match.MatchHallID);
          //  ViewData["PersonID"] = new SelectList(_context.Person, "PersonID", "PersonID", match.PersonID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", match.TeamID);
            return View(match);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["MatchHallID"] = new SelectList(_context.Halls, "MatchHallID", "MatchHallID", match.MatchHallID);
            ViewData["PersonID"] = new SelectList(_context.Person, "PersonID", "PersonID", match.PersonID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", match.TeamID);
            return View(match);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchID,MatchHallID,TeamID,OpponentName,DataSince,DataUntill,Duration,Status,PersonID,isActive")] Match match)
        {
            if (id != match.MatchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.MatchID))
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
            ViewData["MatchHallID"] = new SelectList(_context.Halls, "MatchHallID", "MatchHallID", match.MatchHallID);
            ViewData["PersonID"] = new SelectList(_context.Person, "PersonID", "PersonID", match.PersonID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", match.TeamID);
            return View(match);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Hall)
                .Include(m => m.Referee)
                .Include(m => m.Team)
                .FirstOrDefaultAsync(m => m.MatchID == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.MatchID == id);
        }
    }
}
