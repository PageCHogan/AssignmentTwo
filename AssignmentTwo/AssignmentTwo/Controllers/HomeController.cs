using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssignmentTwo.Models;
using AssignmentTwo.Models.Contact;
using System.Threading;

namespace AssignmentTwo.Controllers
{
    public class HomeController : Controller
    {
		private readonly AroundTheWorldContext _context;

		public HomeController(AroundTheWorldContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

		public IActionResult Contact()
		{
			ViewData["Message"] = "Please leave us a message!";

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Contact(Contact contact)
		{
			//TODO: Have Success message appear AND have a blank model displayed, ie. cleared and not containing recently submitted text.
			if (ModelState.IsValid)
			{
				_context.Add(contact);
				await _context.SaveChangesAsync();
				ViewData["Message"] = "Submission successful thank you.";
				return View(new Contact());
			}
			ViewData["Message"] = "Error! Please fill out all fields.";
			return View(contact);
		}

		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
