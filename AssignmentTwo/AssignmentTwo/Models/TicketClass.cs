using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models
{
    public class TicketClass
    {
		public int TicketClassID { get; set; }
		public string TicketClassType { get; set; }

		public TicketClass()
		{
			TicketClassID = 0;
			TicketClassType = "";
		}
	}
}
