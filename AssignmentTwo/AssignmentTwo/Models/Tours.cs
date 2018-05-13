using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class Tours
    {
		[Key]
		public int TourID { get; set; }
		public string TourName { get; set; }
		public DateTime TourTime { get; set; }
		public decimal TourPrice { get; set; }
		public int TicketsAvailable { get; set; }
		public int TicketsSold { get; set; }
		public int TourDuration { get; set; }

		public Tours()
		{
			TourName = "";
			TourTime = DateTime.MinValue;
			TourPrice = 0;
			TicketsAvailable = 0;
			TicketsSold = 0;
			TourDuration = 0;
		}
    }
}
