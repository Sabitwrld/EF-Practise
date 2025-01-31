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
    }
}
