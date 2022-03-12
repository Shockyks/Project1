using Microsoft.EntityFrameworkCore;

namespace models
{
    public class ContextKlasa : DbContext
    {
        public DbSet<Aerodrom> Aerodromi { get; set; }
        public DbSet<Klasa> Klase { get; set; }
        public DbSet<Let> Letovi { get; set; }
        public ContextKlasa(DbContextOptions options) : base(options)
        {
            
        }
    }
}