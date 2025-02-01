using EF_Practise.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Practise.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS03;Database=PB503CarShop;Trusted_Connection=True;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                        .Property(b => b.Name)
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Model>()
                        .Property(m => m.Name)
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Color>()
                        .Property(c => c.Name)
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Car>()
                        .Property(c => c.MaxSpeed)
                        .IsRequired();

            modelBuilder.Entity<Car>()
                        .Property(c => c.FuelTankCapacity)
                        .IsRequired();

            modelBuilder.Entity<Car>()
                        .Property(c => c.Power)
                        .IsRequired();

            modelBuilder.Entity<Car>()
                        .Property(c => c.DoorCount)
                        .IsRequired();

            modelBuilder.Entity<CarColor>()
                        .HasKey(cc => new { cc.CarId, cc.ColorId });

            modelBuilder.Entity<CarColor>()
                        .HasOne(cc => cc.Car)
                        .WithMany(c => c.CarColors)
                        .HasForeignKey(cc => cc.CarId);

            modelBuilder.Entity<CarColor>()
                        .HasOne(cc => cc.Color)
                        .WithMany(c => c.CarColors)
                        .HasForeignKey(cc => cc.ColorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
