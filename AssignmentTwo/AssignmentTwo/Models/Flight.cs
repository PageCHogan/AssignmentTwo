using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class Flight
    {
		public int FlightID { get; set; }
		public string Departure { get; set; }
		public string Destination { get; set; }
		public DateTime DepartureDate { get; set; }
		public int FlightCapacity { get; set; }
		public int SeatsAvailable { get; set; }

		public Flight()
		{
			FlightID = 0;
			Departure = "";
			Destination = "";
			DepartureDate = DateTime.MinValue;
			FlightCapacity = 0;
			SeatsAvailable = 0;
		}
	}
}
