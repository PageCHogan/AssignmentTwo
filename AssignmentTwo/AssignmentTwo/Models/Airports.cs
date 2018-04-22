using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class Airports
    {
		[Key]
		public int AirportID { get; set; }
		public string AirportLocation { get; set; }
		public string AirportCode { get; set; } //TODO: not really required. Delete if Unused

		public Airports()
		{
			AirportID = 0;
			AirportLocation = "";
			AirportCode = "";
		}
	}
}
