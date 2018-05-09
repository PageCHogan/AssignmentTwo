using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentTwo.Models;
using AssignmentTwo.Services;

namespace AssignmentTwo.Controllers
{
    public class FlightController : Controller
    {
		private FlightService flightService = new FlightService();
        private readonly AroundTheWorldContext _context;

        public FlightController(AroundTheWorldContext context)
        {
            _context = context;
        }

        // GET: Flight
        public async Task<IActionResult> Index()
        {
			List<Airports> airports = await _context.Airports.ToListAsync();
			List<Flight> flights = await _context.Flight.ToListAsync();

			return View(flights);
		}

		// GET: Flight/SearchResults
		public async Task<IActionResult> SearchResults()
		{
			List<Airports> airports = await _context.Airports.ToListAsync();
			List<Flight> flights = await _context.Flight.ToListAsync();

			return View(flights);
		}


		// GET: Flight/Itinerary/5
		public async Task<IActionResult> Itinerary(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			List<Airports> airports = await _context.Airports.ToListAsync();

			var flight = await _context.Flight
				.SingleOrDefaultAsync(m => m.FlightID == id);

			if (flight == null)
			{
				return NotFound();
			}

			return View(flight);
		}

		// GET: Flight/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			List<Airports> airports = await _context.Airports.ToListAsync();

			var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.FlightID == id);

			if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flight/Create
        public IActionResult Create()
        {
			using (AroundTheWorldContext atw = _context)
			{
				var airportsViewDataDB = new SelectList(atw.Airports.ToList(), "AirportID", "AirportLocation");
				ViewData["AirportLocations"] = airportsViewDataDB;
			}
				return View();
        }

        // POST: Flight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightID,Departure,Destination,DepartureDate,FlightCapacity,SeatsAvailable,Price")] Flight flight)
        {
            if (ModelState.IsValid)
            {
				flight.Departure = _context.Airports.Find(flight.Departure.AirportID);
				flight.Destination = _context.Airports.Find(flight.Destination.AirportID);

				_context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

		//TODO: Edit not part of specs. Remove if cannot neatly change flight departure / destination location.
		// GET: Flight/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			List<Airports> airports = await _context.Airports.ToListAsync();

			var flight = await _context.Flight.SingleOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

		//TODO: Edit not part of specs. Remove if cannot neatly change flight departure / destination location.
        // POST: Flight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,DepartureDate,FlightCapacity,SeatsAvailable")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
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
            return View(flight);
        }

        // GET: Flight/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.FlightID == id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.FlightID == id);
        }
    }
}
