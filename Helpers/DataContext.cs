using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ParkingManager> ParkingManagers { get; set; }
        public DbSet<AllocationManager> AllocationManagers { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Parking> Parking { get; set; }
        public DbSet<ParkingHistory> ParkingHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slot>()
                .HasOne(s => s.ParkingSpace)
                .WithMany(ps => ps.Slots);
        }

    }
}