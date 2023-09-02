using ControledeAliens.Models;
using Microsoft.EntityFrameworkCore;

namespace ControledeAliens.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Alien> Aliens { get; set; }
        public DbSet<Earth> AlienEntriesExits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alien>()
                .HasOne(p => p.Planet)
                .WithMany()
                .HasForeignKey(p => p.PlanetId);

            modelBuilder.Entity<AlienPower>()
            .HasKey(ap => new { ap.AlienId, ap.PowerId });

            modelBuilder.Entity<AlienPower>()
                .HasOne(ap => ap.Alien)
                .WithMany(a => a.AlienPowers)
                .HasForeignKey(ap => ap.AlienId);

            modelBuilder.Entity<AlienPower>()
                .HasOne(ap => ap.Power)
                .WithMany(p => p.AlienPowers)
                .HasForeignKey(ap => ap.PowerId);

            modelBuilder.Entity<Power>()
                .HasMany(p => p.AlienPowers)
                .WithOne(ap => ap.Power);

            modelBuilder.Entity<AlienPower>()
                .HasOne(ap => ap.Alien)
                .WithMany(a => a.AlienPowers)
                .HasForeignKey(ap => ap.AlienId);


            modelBuilder.Entity<Earth>()
                .HasOne(a => a.Alien)
                .WithMany()
                .HasForeignKey(a => a.AlienId);

        }
    }
}
