using Microsoft.EntityFrameworkCore;
using Space_Rover.Core.Entity;

namespace Space_Rover.Infrastructr;

public class AppDbContext:DbContext
{
   
  
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
        }
        public DbSet<Rover> Rovers { get; set; }
        public DbSet<Planet>Planets { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              
             
        } 
   
}

