using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models.FlightSearchViewModel
{
	public class FlightSearchViewModel
	{
		public int ID { get; set; }
		public Airports Departure { get; set; }
		public Airports Destination { get; set; }
		public bool ReturnFlight { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public int Passengers { get; set; }
		public TicketClass TicketClass { get; set; }

		public FlightSearchViewModel()
		{
			Departure = new Airports();
			Destination = new Airports();
			ReturnFlight = false;
			DepartureDate = DateTime.MinValue;
			ReturnDate = DateTime.MinValue;
			Passengers = 0;
			TicketClass = new TicketClass();
		}
	}
}
