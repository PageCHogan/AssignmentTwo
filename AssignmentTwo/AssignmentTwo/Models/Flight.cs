﻿using System;
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
		public decimal Price { get; set; }

		public Flight()
		{
			FlightID = 0;
			Departure = new Airports();
			Destination = new Airports();
			DepartureDate = DateTime.MinValue;
			FlightCapacity = 0;
			SeatsAvailable = 0;
			Price = 0;
		}
	}
}
