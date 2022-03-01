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
    public class MatchHallsController : Controller
    {
        private readonly MasContext _context;

        public MatchHallsController(MasContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Halls.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {



            ViewModelHall mymodel = new ViewModelHall();
            var masContext = _context.Matches.Include(m => m.Hall).Include(m => m.Referee).Include(m => m.Team);
            var list = (await masContext.ToListAsync());

            mymodel.AllMatches = list.FindAll(s => s.MatchHallID.Equals(id));
            mymodel.ThisHall = (await _context.Halls.FindAsync(id));




            if (id == null)
            {
                return NotFound();
            }

            var matchHall = await _context.Halls
                .FirstOrDefaultAsync(m => m.MatchHallID == id);
            if (matchHall == null)
            {
                return NotFound();
            }

            return View(mymodel);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchHallID,SeatNumber,HallName")] MatchHall matchHall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchHall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchHall);
        }

    
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchHall = await _context.Halls.FindAsync(id);
            if (matchHall == null)
            {
                return NotFound();
            }
            return View(matchHall);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchHallID,SeatNumber,HallName")] MatchHall matchHall)
        {
            if (id != matchHall.MatchHallID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchHall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchHallExists(matchHall.MatchHallID))
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
            return View(matchHall);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchHall = await _context.Halls
                .FirstOrDefaultAsync(m => m.MatchHallID == id);
            if (matchHall == null)
            {
                return NotFound();
            }

            return View(matchHall);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchHall = await _context.Halls.FindAsync(id);
            _context.Halls.Remove(matchHall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchHallExists(int id)
        {
            return _context.Halls.Any(e => e.MatchHallID == id);
        }
    }
}
