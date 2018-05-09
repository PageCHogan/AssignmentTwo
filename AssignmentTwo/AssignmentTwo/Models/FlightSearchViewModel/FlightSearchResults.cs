using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class FlightSearchResults
    {
		public List<Flight> Flights { get; set; }

		public FlightSearchResults()
		{
			Flights = new List<Flight>();
		}
    }
}
