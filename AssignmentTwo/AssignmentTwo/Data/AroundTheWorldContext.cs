using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssignmentTwo.Models
{
    public class AroundTheWorldContext : DbContext
    {
        public AroundTheWorldContext (DbContextOptions<AroundTheWorldContext> options)
            : base(options)
        {
        }

		public DbSet<AssignmentTwo.Models.Flight> Flight { get; set; }
		public DbSet<AssignmentTwo.Models.Airports> Airports { get; set; }
	}
}
