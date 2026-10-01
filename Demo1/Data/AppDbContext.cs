using Demo1.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(a => a.DriverLicenseNumber).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(a => a.VIN).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Vehicle>().Property(a => a.Price).HasPrecision(12, 2);
            modelBuilder.Entity<Sale>().Property(a => a.SalePrice).HasPrecision(12, 2);
            modelBuilder.Entity<Vehicle>().Property(a => a.Status).HasDefaultValue("Available");





            modelBuilder.Entity<Vehicle>()
                .HasOne(c => c.Category)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.CategoryId);


            modelBuilder.Entity<Sale>().HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.customerId);


            modelBuilder.Entity<Sale>().HasOne(s => s.Employee)
                .WithMany(e => e.Sales)
                .HasForeignKey(s => s.EmployeeId);


            modelBuilder.Entity<CustomerProfile>()
                .HasOne(c => c.Customer)
                .WithOne(cp => cp.CustomerProfile)
                .HasForeignKey<CustomerProfile>(cp => cp.CustomerId);


            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Vehicle)
                .WithOne(v => v.Sale)
                .HasForeignKey<Sale>(s => s.VehicleId);




            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Sedan",
                Description = "Comfortable passenger cars",
            },
             new Category
             {
                 Id = 2,
                 Name = "SUV",
                 Description = "Sport utility vehicles",
             },
            new Category
            {
                Id = 3,
                Name = " Hatchback",
                Description = "Compact practical cars",
            }
            );


            modelBuilder.Entity<Vehicle>().HasData(
          new Vehicle
          {
              Id = 1,
              Make = "Toyota Corolla",
              Model = "Corolla",
              Year = 2024,
              Color = "White",
              Price = 650000,
              Mileage = 12000,
              VIN = "VIN00000000000001",
              FuelType = "Petrol",
              Transmission = "Automatic",
              Status = "Available",

                CategoryId = 1,
                SaleId = 2
          },
            new Vehicle
            {
                Id = 2,
                Make = "Hyundai",
                Model = "Elantra",
                Year = 2023,
                Color = "Black",
                Price = 590000,
                Mileage = 18000,
                VIN = "VIN000000000000",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Status = "Available",
                CategoryId = 2,
                SaleId = 3
            },
            new Vehicle
            {
                Id = 3,
                Make = "Kia",
                Model = "Sportage",
                Year = 2024,
                Color = "Gray",
                Price = 980000,
                Mileage = 9000,
                VIN = "VIN00000000000002",
                FuelType = "Petrol",
                Transmission = "Automatic",
                Status = "Available",
                CategoryId = 3,
                SaleId = 1
            }
          );


            modelBuilder.Entity<Customer>().HasData(

                new Customer
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@example.com",
                    Phone = "01010000001",
                    DriverLicenseNumber = "DL100001"

                },

                new Customer
                {
                    Id = 2,
                    FullName = "Mona Adel",
                    Email = "Mona.Adel@example.com",
                    Phone = "01010000002",
                    DriverLicenseNumber = "DL100002"

                },

                new Customer
                {
                    Id = 3,
                    FullName = "Omar Khaled",
                    Email = "Omar.Khaled@example.com",
                    Phone = "01010000003",
                    DriverLicenseNumber = "DL100003"

                }
            );


            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile
                {
                    Id = 1,
                    Address = "12 Nile St.Cairo",
                    City = "Cairo",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1992, 3, 12),
                    CustomerId = 1
                },
                new CustomerProfile
                {
                    Id = 2,
                    Address = "25 Tahrir St.Giza",
                    City="Giza",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1995, 7, 24),
                    CustomerId = 2
                },
                new CustomerProfile
                {
                    Id = 3,
                    Address = "18 El Nasr St.Cairo",
                    City = "Cairo",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1988, 11, 5),
                    CustomerId =3
                }
             );


            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    Id = 1,
                    FullName = "Mostafa Nabil",
                    Position = "Sales Manager",
                    Email = "mostafa.nabil@autodrive.com",
                    Phone = "01020000001",
                    HireDate = new DateTime(2021, 1, 10)
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Aya Emad",
                    Position = "Sales Consultant",
                    Email = "aya.emad@autodrive.com",
                    Phone = "01020000002",
                    HireDate = new DateTime(2022, 4, 15)
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Hassan Ali",
                    Position = "Sales Consultant",
                    Email = " hassan.ali@autodrive.com ",
                    Phone = "01020000003",
                    HireDate = new DateTime(2023 , 02 , 20)
                }
             );

            modelBuilder.Entity<Sale>().HasData(

                new Sale
                {
                    Id = 1,
                    SaleDate = new DateTime(2026, 8, 15),
                    SalePrice = 1750000,
                    PaymentMethod = "Bank Transfer",
                    Notes = "Completed sale.",
                    customerId = 1,
                    EmployeeId = 1,
                    VehicleId = 1
                },
                new Sale
                {
                    Id = 2,
                    SaleDate = new DateTime(2026, 8, 22),
                    SalePrice = 1850000,
                    PaymentMethod = "Bank Transfer",
                    Notes = "Completed sale.",
                    customerId = 2,
                    EmployeeId = 2,
                    VehicleId = 2
                },
                new Sale
                {
                    Id = 3,
                    SaleDate = new DateTime(2026, 9, 5),
                    SalePrice = 510000,
                    PaymentMethod = "Cash",
                    Notes = "Completed sale.",
                    customerId = 3,
                    EmployeeId = 3,
                    VehicleId = 3
                }
            );






          base.OnModelCreating(modelBuilder);


        }
    }
}
