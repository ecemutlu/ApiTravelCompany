using System.Reflection.Metadata;
using ApiTravelCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTravelCompany.Db
{
    public class TravelContext:DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
       : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
