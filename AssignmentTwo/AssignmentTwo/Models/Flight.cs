using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class Flight
    {
		public int FlightID { get; set; }
		public Airports Departure { get; set; }
		public Airports Destination { get; set; }
		public DateTime DepartureDate { get; set; }
		public int FlightCapacity { get; set; }
		public int SeatsAvailable { get; set; }

		public Flight()
		{
			FlightID = 0;
			Departure = null;
			Destination = null;
			DepartureDate = DateTime.MinValue;
			FlightCapacity = 0;
			SeatsAvailable = 0;
		}
	}
}
