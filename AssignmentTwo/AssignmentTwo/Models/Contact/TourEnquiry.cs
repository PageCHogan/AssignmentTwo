using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTwo.Models.Contact
{
    public class TourEnquiry
    {
		[Key]
		public int ID { get; set; }

		[Required(ErrorMessage = "Please enter tour name")]
		public string TourName { get; set; }

		[Required(ErrorMessage = "Please enter your name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter your email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter your message")]
		public string Message { get; set; }

		public TourEnquiry()
		{
			TourName = "";
			Name = "";
			Email = "";
			Message = "";
		}
	}
}
