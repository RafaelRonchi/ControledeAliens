using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ControledeAliens.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Power> Powers { get; set; }
        public DbSet<Planet> Planets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
