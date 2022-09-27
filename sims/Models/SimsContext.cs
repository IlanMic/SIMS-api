using Microsoft.EntityFrameworkCore;

namespace sims.Models
{
    public class SimsContext : DbContext
    {
       public SimsContext(DbContextOptions<SimsContext> options): base(options)
        {
        }

        public DbSet<DataOwner> DataOwners { get; set; } = null!;
        public DbSet<Format> Formats { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<Profession> Professions { get; set; } = null!;
        public DbSet<Theme> Themes { get; set; } = null!;
        public DbSet<UpdateFrequency> UpdateFrequencies { get; set; } = null!;
    }
}
