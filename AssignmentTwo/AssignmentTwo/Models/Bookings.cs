using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class Bookings
    {
		[Key]
		public int BookingID { get; set; }
		public Flight PrimaryFlight { get; set; }
		public Flight ReturnFlight { get; set; }
		public bool AdditionalLuggage { get; set; }
		public Decimal Price { get; set; }
		public int Passengers { get; set; }
		public TicketClass TicketClass { get; set; }
		public bool Return { get; set; }

		public Bookings()
		{
			BookingID = 0;
			PrimaryFlight = new Flight();
			ReturnFlight = new Flight();
			AdditionalLuggage = false;
			Price = 0;
			Passengers = 0;
			TicketClass = new TicketClass();
			Return = false;
		}
	}
}
