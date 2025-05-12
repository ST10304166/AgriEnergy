using AgriEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "farmer1@example.com",
                    Password = "password123",
                    Address = "Farm 1, Region A",
                    PhoneNumber = "0101234567",
                    RegistrationDate = DateTime.Now
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Jane Admin",
                    Email = "admin@example.com",
                    Password = "admin123",
                    Role = "Employee"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Maize",
                    Category = "Grains",
                    ProductionDate = DateTime.Now.AddDays(-10),
                    FarmerId = 1
                });
        }
    }
}