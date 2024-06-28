using Microsoft.EntityFrameworkCore;



namespace RaviSirTaskJune20.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }

    }
}
