using Microsoft.EntityFrameworkCore;

namespace coworking_salas.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 
        }
          public DbSet<Sala> Salas { get; set; }
        public DbSet<Uso> Usos { get; set; } 
    
    }
    
}
