using Microsoft.EntityFrameworkCore;
using TestesComBanco.Models;

namespace TestesComBanco.Context
{
    public class BancoDbContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }

        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agency>().HasData(new Agency[]
            {
                new Agency { Id = 1, Name = "Agency 1" },
                new Agency { Id = 2, Name = "Agency 2" },
                new Agency { Id = 3, Name = "Agency 3" },
                new Agency { Id = 4, Name = "Agency 4" },
                new Agency { Id = 5, Name = "Agency 5" },
                new Agency { Id = 6, Name = "Agency 6" },
            });
        }
    }
}
