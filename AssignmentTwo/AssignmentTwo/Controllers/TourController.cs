using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentTwo.Models;

namespace AssignmentTwo.Controllers
{
    public class TourController : Controller
    {
        private readonly AroundTheWorldContext _context;

        public TourController(AroundTheWorldContext context)
        {
            _context = context;
        }

        // GET: Tour
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tours.ToListAsync());
        }

        // GET: Tour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours
                .SingleOrDefaultAsync(m => m.TourID == id);
            if (tours == null)
            {
                return NotFound();
            }

            return View(tours);
        }

        // GET: Tour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourID,TourName,TourTime,TourPrice,TicketsAvailable,TicketsSold,TourDuration,AdditionalInformation")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tours);
        }

        // GET: Tour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours.SingleOrDefaultAsync(m => m.TourID == id);
            if (tours == null)
            {
                return NotFound();
            }
            return View(tours);
        }

        // POST: Tour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourID,TourName,TourTime,TourPrice,TicketsAvailable,TicketsSold,TourDuration,AdditionalInformation")] Tours tours)
        {
            if (id != tours.TourID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToursExists(tours.TourID))
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
            return View(tours);
        }

        // GET: Tour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours
                .SingleOrDefaultAsync(m => m.TourID == id);
            if (tours == null)
            {
                return NotFound();
            }

            return View(tours);
        }

        // POST: Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tours = await _context.Tours.SingleOrDefaultAsync(m => m.TourID == id);
            _context.Tours.Remove(tours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToursExists(int id)
        {
            return _context.Tours.Any(e => e.TourID == id);
        }
    }
}
