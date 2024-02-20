using Microsoft.EntityFrameworkCore;
using Space_Rover.Core.Entity;

namespace Space_Rover.Infrastructr;

public class AppDbContext:DbContext
{
   
  
        public AppDbContext(DbContextOptions options):base (options)
        {
        }
        public DbSet<Rover> Rover { get; set; }
        public DbSet<Planet>Planet { get; set; }
   
}

