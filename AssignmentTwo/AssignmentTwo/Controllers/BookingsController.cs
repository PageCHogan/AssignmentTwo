using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentTwo.Models;
using System.Collections;

namespace AssignmentTwo.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AroundTheWorldContext _context;

        public BookingsController(AroundTheWorldContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
			return RedirectToAction(nameof(Create));
			//return View(await _context.Bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .SingleOrDefaultAsync(m => m.BookingID == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
			//Dictionary<string, string> flightDetails = new Dictionary<string, string>();
			//List<Flight> flights = _context.Flight.ToList();

			
				var airportsViewDataDB = new SelectList(_context.Airports.ToList(), "AirportID", "AirportLocation");
				ViewData["AirportLocations"] = airportsViewDataDB;
				
				//foreach(Flight flight in flights)
				//{
				//	flightDetails.Add(flight.FlightID.ToString(), flight.Departure.AirportLocation + " to " + flight.Destination.AirportLocation);
				//}
				//SelectList SelectList = new SelectList((IEnumerable)flightDetails, "Key", "Value");
				//var flightsViewDataDB = new SelectList(flightDetails, "FlightID", "FlightID");
				//var flightsViewDataDB = new SelectList(flightDetails.ToList());

				//var flightsViewDataDB = new SelectList((IEnumerable)flightDetails, flightDetails.Keys.ToString(), flightDetails.Values.ToString());
				//ViewData["AvailableFlights"] = flightsViewDataDB.Items;

				var flightsViewDataDB = new SelectList(_context.Flight.ToList(), "FlightID", "FlightID");
				ViewData["AvailableFlights"] = flightsViewDataDB;			return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,PrimaryFlight,ReturnFlight,PassengersName,EmailAddress,AdditionalLuggage,Passengers,ReturnTrip,PassportNumber")] Bookings bookings)
        {
			var flightsViewDataDB = new SelectList(_context.Flight.ToList(), "FlightID", "FlightID");
			ViewData["AvailableFlights"] = flightsViewDataDB;

			var airportsViewDataDB = new SelectList(_context.Airports.ToList(), "AirportID", "AirportLocation");
			ViewData["AirportLocations"] = airportsViewDataDB;


			if (ModelState.IsValid)
            {
				List<Airports> airports = await _context.Airports.ToListAsync();
				List<Flight> flights = await _context.Flight.ToListAsync();

				if(bookings.PrimaryFlight.FlightID > 0)
					bookings.PrimaryFlight = _context.Flight.Find(bookings.PrimaryFlight.FlightID);

				if (bookings.ReturnTrip && bookings.ReturnFlight.FlightID > 0)
					bookings.ReturnFlight = _context.Flight.Find(bookings.ReturnFlight.FlightID);
				else
					bookings.ReturnFlight.FlightID = 0;

				bookings.Price = (bookings.PrimaryFlight.Price + bookings.ReturnFlight.Price) * bookings.Passengers;

				if (bookings.AdditionalLuggage)
					bookings.Price += (15 * bookings.Passengers);

				

				_context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
			//ViewBag.errormessage = "no bueno";
			return View(bookings);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.SingleOrDefaultAsync(m => m.BookingID == id);
            if (bookings == null)
            {
                return NotFound();
            }
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,PassengersName,EmailAddress,AdditionalLuggage,Price,Passengers,ReturnTrip,PassportNumber")] Bookings bookings)
        {
            if (id != bookings.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.BookingID))
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
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .SingleOrDefaultAsync(m => m.BookingID == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.SingleOrDefaultAsync(m => m.BookingID == id);
            _context.Bookings.Remove(bookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}
