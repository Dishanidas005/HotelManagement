using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Models
{
    public class hmsContext:DbContext

    {
        public hmsContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<Booking> Bookings{ get; set; }
        public object Booking { get; internal set; }
    }
}
