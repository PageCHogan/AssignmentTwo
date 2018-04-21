using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class Bookings
    {
		public int BookingID { get; set; }
		public Flight FlightReferenceID { get; set; } //TODO: not 100% on the best method to link this to the flight tables within the database.
		public bool AdditionalLuggage { get; set; }
		public Decimal Price { get; set; }
		public int Passengers { get; set; }
		public TicketClass TicketClass { get; set; }
		public bool Return { get; set; }

		public Bookings()
		{
			BookingID = 0;
			FlightReferenceID = new Flight();
			AdditionalLuggage = false;
			Price = 0;
			Passengers = 0;
			TicketClass = new TicketClass();
			Return = false;
		}
	}
}
