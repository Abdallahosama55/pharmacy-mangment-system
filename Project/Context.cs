
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Project
{
    public class Context : DbContext
    {
        public DbSet<EmployeeClass> Employee { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<MedBills> MedBills { get; set; }
        public DbSet<Company> Company { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data source=DESKTOP-A7S437N; initial catalog = MedicineSystem;  Integrated Security=True; trust server certificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                Name = "Taba medical",
                Address = "Cairo",
                Phone = "01068100402",
                exist = 1
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 2,
                Name = "Farco",
                Address = "Assiut",
                Phone = "01007837834",
                exist = 1
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 3,
                Name = "Amanco",
                Address = "Sohag",
                Phone = "01109283484",
                exist = 1
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 4,
                Name = "Pharma",
                Address = "Matroh",
                Phone = "01113468920",
                exist = 1
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 5,
                Name = "Sanofi",
                Address = "Cairo",
                Phone = "01064892436",
                exist = 1
            });
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 6,
                Name = "Gsk",
                Address = "Cairo",
                Phone = "01173630273",
                exist = 1
            });

            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 1,
                Name = "rapiflam",
                UnitPrice = 50,
                quantity = 10,
                CompanyPrice = 40,
                Profit = 10,
                Type = "Tablet",
                CompID = 6,
                exist = 1,
                ExpDate = new DateTime(2028, 5, 26),
                ProductionDate = new DateTime(2020, 5, 26),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 2,
                Name = "cataflam",
                UnitPrice = 20,
                quantity = 10,
                CompanyPrice = 15,
                Profit = 5,
                Type = "Tablet",
                CompID = 4,
                exist = 1,
                ExpDate = new DateTime(2024, 2, 26),
                ProductionDate = new DateTime(2020, 3, 26),
                EnteredDate = new DateTime(2020, 3, 26)

            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 3,
                Name = "buscoban",
                UnitPrice = 100,
                quantity = 10,
                Type = "Tablet",
                CompID = 3,
                CompanyPrice = 80,
                Profit = 20,
                exist = 1,
                ExpDate = new DateTime(2022, 5, 26),
                ProductionDate = new DateTime(2021, 5, 26),
                EnteredDate = new DateTime(2020, 3, 26)

            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 4,
                Name = "vegaskiin",
                UnitPrice = 10.95,
                quantity = 10,
                CompanyPrice = 8.95,
                Profit = 2,
                Type = "injection",
                CompID = 2,
                exist = 1,
                ExpDate = new DateTime(2026, 9, 26),
                ProductionDate = new DateTime(2022, 9, 26),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 5,
                Name = "meranda",
                UnitPrice = 150,
                CompanyPrice =120,
                Profit = 30,
                quantity = 10,
                Type = "injection",
                CompID = 1,
                exist = 1,
               
                ExpDate = new DateTime(2025, 5, 15),
                ProductionDate = new DateTime(2021, 5, 15),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 6,
                Name = "teraicten",
                UnitPrice = 80,
                quantity = 10,
                Type = "Syrup",
                CompanyPrice = 65,
                Profit = 15,
                CompID = 1,
                exist = 1,
                ExpDate = new DateTime(2025, 9, 13),
                ProductionDate = new DateTime(2022, 9, 11),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 7,
                Name = "servetam",
                UnitPrice = 39.5,
                quantity = 10,
                Type = "Tablet",
                CompID = 2,
                CompanyPrice = 36.5,
                Profit = 3,
                exist = 1,
                ExpDate = new DateTime(2025, 5, 15),
                ProductionDate = new DateTime(2021, 5, 15),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 8,
                Name = "banadol",
                UnitPrice = 100,
                quantity = 10,
                Type = "Tablet",
                CompID = 5,
                CompanyPrice = 85,
                Profit = 15,
                exist = 1,
                ExpDate = new DateTime(2026, 9, 6),
                ProductionDate = new DateTime(2022, 9, 6),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 9,
                Name = "depakin",
                UnitPrice = 100,
                CompanyPrice = 85,
                Profit = 15,
                quantity = 10,
                Type = "Syrup",
                CompID = 3,
                exist = 1,
                ExpDate = new DateTime(2025, 5, 26),
                ProductionDate = new DateTime(2021, 5, 26),
                EnteredDate = new DateTime(2020, 3, 26)
            });
            modelBuilder.Entity<Medicine>().HasData(new Medicine
            {
                ID = 10,
                Name = "profien",
                UnitPrice = 10,
                quantity = 10,
                CompanyPrice = 8.50,
                Profit = 1.50,
                Type = "Syrup",
                CompID = 3,
                exist = 1,
                ExpDate = new DateTime(2023, 2, 12),
                ProductionDate = new DateTime(2022, 9, 26),
                EnteredDate = new DateTime(2020, 3, 26)
            });

            modelBuilder.Entity<EmployeeClass>().HasData(new EmployeeClass
            {
                id = 1,
                name = "Mayar",
                salary = 1000,
                Age = 23,
                phone = "0100000",
                password = "0123",
                Email = "Mayar@admin",
                exist = 1
            });
            modelBuilder.Entity<EmployeeClass>().HasData(new EmployeeClass
            {

                id = 2,
                name = "Mariem",
                salary = 2000,
                Age = 25,
                phone = "0100000",
                password = "1234",
                Email = "Mariem@Employee",
                exist = 1
            });
            modelBuilder.Entity<EmployeeClass>().HasData(new EmployeeClass
            {


                id = 3,
                name = "hadeer",
                salary = 3000,
                Age = 24,
                phone = "0100000",
                password = "12345",
                Email = "hadeer@Employee",
                exist = 1

            });
            modelBuilder.Entity<EmployeeClass>().HasData(new EmployeeClass
            {

                id = 4,
                name = "Reem",
                salary = 1000,
                Age = 26,
                phone = "01010101",
                password = "1679",
                Email = "Reem@admin",
                exist = 1
            });




        }


    }
}
