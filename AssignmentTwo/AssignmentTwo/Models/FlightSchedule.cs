using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class FlightSchedule
    {
		public Flight FlightData { get; set; }
		public Airports AirportData { get; set; }

		public FlightSchedule()
		{
			FlightData = new Flight();
			AirportData = new Airports();
		}
    }
}
