using ControledeAliens.Models;
using Microsoft.EntityFrameworkCore;

namespace ControledeAliens.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Alien> Alienes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alien>()
                .HasOne(p => p.Planet)
                .WithMany()
                .HasForeignKey(p => p.PlanetId);

            modelBuilder.Entity<Alien>()
                .HasOne(p => p.Power)
                .WithMany()
                .HasForeignKey(p => p.PowerId);

        }
    }
}
