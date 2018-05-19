using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentTwo.Models;
using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace AssignmentTwo.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AroundTheWorldContext _context;

        public BookingsController(AroundTheWorldContext context)
        {
            _context = context;
        }

		//If logged in user has booked flights able to view history, if no user logged in will see all booked flights. If no flights will default to create booking page.
        // GET: Bookings
        public async Task<IActionResult> Index()
        {
			string loggedUser = User.Identity.Name;

			List<Airports> airports = await _context.Airports.ToListAsync();
			List<Flight> flights = await _context.Flight.ToListAsync();
			List<TicketClass> ticketClasses = await _context.TicketClass.ToListAsync();

			if (loggedUser != null)
			{
				var userBookings = await _context.Bookings.Where(o => o.UserID == loggedUser).ToListAsync();
				if (userBookings.Count > 0)
					return View(userBookings);
				else
					return RedirectToAction(nameof(Create));
			}
			else
			{
				var allBookings = await _context.Bookings.ToListAsync();
				if (allBookings.Count > 0)
					return View(allBookings);
				else
					return RedirectToAction(nameof(Create));
			}
		}

		// GET: Bookings/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			List<Airports> airports = await _context.Airports.ToListAsync();
			List<Flight> flights = await _context.Flight.ToListAsync();
			List<TicketClass> ticketClasses = await _context.TicketClass.ToListAsync();

			var bookings = await _context.Bookings
                .SingleOrDefaultAsync(m => m.BookingID == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create(int flightID)
        {
			var flightsViewDataDB = new SelectList(_context.Flight.ToList(), "FlightID", "FlightID");
			ViewData["AvailableFlights"] = flightsViewDataDB;

			var ticketClassViewDataDB = new SelectList(_context.TicketClass.ToList(), "TicketClassID", "TicketClassType");
			ViewData["TicketClasses"] = ticketClassViewDataDB;

			if(flightID == 0)
				return View();

			return View(new Bookings() { PrimaryFlight = new Flight() { FlightID = flightID } });
		}

		// POST: Bookings/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,PrimaryFlight,ReturnFlight,PassengersName,EmailAddress,AdditionalLuggage,Passengers,ReturnTrip,PassportNumber,TicketClass")] Bookings bookings)
        {
			if (ModelState.IsValid)
            {
				List<Airports> airports = await _context.Airports.ToListAsync();
				List<Flight> flights = await _context.Flight.ToListAsync();
				List<TicketClass> ticketClasses = await _context.TicketClass.ToListAsync();

				if (bookings.PrimaryFlight.FlightID > 0)
					bookings.PrimaryFlight = _context.Flight.Find(bookings.PrimaryFlight.FlightID);

				if (bookings.ReturnTrip && bookings.ReturnFlight.FlightID > 0)
					bookings.ReturnFlight = _context.Flight.Find(bookings.ReturnFlight.FlightID);
				else
					bookings.ReturnFlight.FlightID = 0;

				bookings.Price = (bookings.PrimaryFlight.Price + bookings.ReturnFlight.Price) * bookings.Passengers;

				if (bookings.AdditionalLuggage)
					bookings.Price += (15 * bookings.Passengers);

				bookings.TicketClass = _context.TicketClass.Find(bookings.TicketClass.TicketClassID);

				string user = User.Identity.Name;
				if (user != null)
					bookings.UserID = User.Identity.Name.ToString();

				_context.Add(bookings);
                await _context.SaveChangesAsync();
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
