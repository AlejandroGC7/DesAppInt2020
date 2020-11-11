using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HumanResourcesAGC.Models;

namespace HumanResourcesAGC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HResourceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Regions.Any())
            {
                return;   // DB has been seeded
            }

        //Region
            var regions = new Region[]
            {
                new Region { RegionID = 1, RegionName = "Africa" },
                new Region { RegionID = 2, RegionName = "Asia" },
                new Region { RegionID = 3, RegionName = "Europa" },
                new Region { RegionID = 4, RegionName = "Latinoamerica" },
                new Region { RegionID = 5, RegionName = "Norteamerica" },
                new Region { RegionID = 6, RegionName = "Sudamerica" },
                new Region { RegionID = 7, RegionName = "Oceania" },
                new Region { RegionID = 8, RegionName = "Otra" }
            };

            foreach (Region r in regions)
            {
                context.Regions.Add(r);
            }
            context.SaveChanges();

        //Country
            var countries = new Country[]
            {
                new Country { ISO = "MX", CountryName = "Mexico",
                    RegionID  = regions.Single( i => i.RegionName == "Latinoamerica").RegionID },
                new Country { ISO = "BR", CountryName = "Brasil",
                    RegionID  = regions.Single( i => i.RegionName == "Sudamerica").RegionID },
                new Country { ISO = "GB", CountryName = "Reino Unido",
                    RegionID  = regions.Single( i => i.RegionName == "Europa").RegionID },
                new Country { ISO = "AU", CountryName = "Australia",
                    RegionID  = regions.Single( i => i.RegionName == "Oceania").RegionID },
                new Country { ISO = "US", CountryName = "Estados Unidos de America",
                    RegionID  = regions.Single( i => i.RegionName == "Norteamerica").RegionID },
                new Country { ISO = "CN", CountryName = "China",
                    RegionID  = regions.Single( i => i.RegionName == "Asia").RegionID },
                new Country { ISO = "JP", CountryName = "Japon",
                    RegionID  = regions.Single( i => i.RegionName == "Asia").RegionID },
                new Country { ISO = "PT", CountryName = "Portugal",
                    RegionID  = regions.Single( i => i.RegionName == "Europa").RegionID },
                new Country { ISO= "EG", CountryName = "Egipto",
                    RegionID  = regions.Single( i => i.RegionName == "Africa").RegionID },
                new Country { ISO = "SN", CountryName = "Senegal",
                    RegionID  = regions.Single( i => i.RegionName == "Africa").RegionID }
            };

            foreach (Country c in countries)
            {
                context.Countries.Add(c);
            }
            context.SaveChanges();

        //Location
            var locations = new Location[]
            {
                new Location { StreetAddress = "Condesa", PostalCode = "98600", City = "Guadalupe", StateProvince = "Zacatecas",
                    CountryID  = countries.Single( i => i.ISO == "MX").CountryID },
                new Location { StreetAddress = "Fuentes", PostalCode = "98611", City = "Fresnillo", StateProvince = "Zacatecas",
                    CountryID  = countries.Single( i => i.ISO == "MX").CountryID },
                new Location { StreetAddress = "Lombard Street", PostalCode = "92300", City = "Londres", StateProvince = "Londres",
                    CountryID  = countries.Single( i => i.ISO == "GB").CountryID },
                new Location { StreetAddress = "Collins Street", PostalCode = "71682", City = "Melbourne", StateProvince = "Melbourne",
                    CountryID  = countries.Single( i => i.ISO == "AU").CountryID },
                new Location { StreetAddress = "Vegas Boulevard", PostalCode = "59101", City = "Las Vegas", StateProvince = "Nevada",
                    CountryID  = countries.Single( i => i.ISO == "US").CountryID },
                new Location { StreetAddress = "Wall Street", PostalCode = "69261", City = "Manhattan", StateProvince = "New York",
                    CountryID  = countries.Single( i => i.ISO == "US").CountryID },
                new Location { StreetAddress = "Guozijian", PostalCode = "10920", City = "Beijing", StateProvince = "Beijing",
                    CountryID  = countries.Single( i => i.ISO == "CN").CountryID },
                new Location { StreetAddress = "Takeshita", PostalCode = "11289", City = "Harajuku", StateProvince = "Tokio",
                    CountryID  = countries.Single( i => i.ISO == "JP").CountryID },
                new Location { StreetAddress = "Rua Augusta", PostalCode = "23989", City = "Baixa", StateProvince = "Lisboa",
                    CountryID  = countries.Single( i => i.ISO == "PT").CountryID },
                new Location { StreetAddress = "El Gamaleya", PostalCode = "76612", City = "El Cairo", StateProvince = "El Cairo",
                    CountryID  = countries.Single( i => i.ISO == "EG").CountryID },
                new Location { StreetAddress = "Saint Louis", PostalCode = "20913", City = "Saint-Louis", StateProvince = "Saint-Louis",
                    CountryID  = countries.Single( i => i.ISO == "SN").CountryID },
                new Location { StreetAddress = "Hidalgo", PostalCode = "92356", City = "Monterrey", StateProvince = "Nuevo Leon",
                    CountryID  = countries.Single( i => i.ISO == "MX").CountryID }
            };

            foreach (Location l in locations)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();

        //Department
            var departments = new Department[]
            {
                new Department { DepartmentName = "Administration-MX",
                    LocationID  = locations.Single( i => i.PostalCode == "98600").LocationID },
                new Department { DepartmentName = "Marketing-MX",
                    LocationID  = locations.Single( i => i.PostalCode == "98600").LocationID },
                new Department { DepartmentName = "IT-MX",
                    LocationID  = locations.Single( i => i.PostalCode == "98600").LocationID },
                new Department { DepartmentName = "Shipping-MX",
                    LocationID  = locations.Single( i => i.PostalCode == "98611").LocationID },
                new Department { DepartmentName = "IT-GB",
                    LocationID  = locations.Single( i => i.PostalCode == "92300").LocationID },
                new Department { DepartmentName = "Marketing-AU",
                    LocationID  = locations.Single( i => i.PostalCode == "71682").LocationID },
                new Department { DepartmentName = "Sales-AU",
                    LocationID  = locations.Single( i => i.PostalCode == "71682").LocationID },
                new Department { DepartmentName = "Administration-US",
                    LocationID  = locations.Single( i => i.PostalCode == "59101").LocationID },
                new Department { DepartmentName = "Shipping-US",
                    LocationID  = locations.Single( i => i.PostalCode == "59101").LocationID },
                new Department { DepartmentName = "IT-US",
                    LocationID  = locations.Single( i => i.PostalCode == "69261").LocationID },
                new Department { DepartmentName = "Sales-US",
                    LocationID  = locations.Single( i => i.PostalCode == "69261").LocationID },
                new Department { DepartmentName = "Administration-CN",
                    LocationID  = locations.Single( i => i.PostalCode == "10920").LocationID },
                new Department { DepartmentName = "Marketing-JP",
                    LocationID  = locations.Single( i => i.PostalCode == "11289").LocationID },
                new Department { DepartmentName = "Executive-JP",
                    LocationID  = locations.Single( i => i.PostalCode == "11289").LocationID },
                new Department { DepartmentName = "Executive-PT",
                    LocationID  = locations.Single( i => i.PostalCode == "23989").LocationID },
                new Department { DepartmentName = "Sales-EG",
                    LocationID  = locations.Single( i => i.PostalCode == "76612").LocationID },
                new Department { DepartmentName = "Accounting-SN",
                    LocationID  = locations.Single( i => i.PostalCode == "20913").LocationID },
                new Department { DepartmentName = "Shipping-SN",
                    LocationID  = locations.Single( i => i.PostalCode == "20913").LocationID },
                new Department { DepartmentName = "Executive-SN",
                    LocationID  = locations.Single( i => i.PostalCode == "20913").LocationID },
                new Department { DepartmentName = "Contracting-MX",
                    LocationID  = locations.Single( i => i.PostalCode == "92356").LocationID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

        //Job
            var jobs = new Job[]
            {
                new Job { JobTitle = "Administrative Assistant", Difficulty = Difficulty.Media, MinSalary = 14500, MaxSalary = 20000 },
                new Job { JobTitle = "Administrative Coordinator", Difficulty = Difficulty.Alta, MinSalary = 15600, MaxSalary = 22000 },
                new Job { JobTitle = "Administrative Director", Difficulty = Difficulty.Alta, MinSalary = 2100, MaxSalary = 28900 },
                new Job { JobTitle = "Marketing Assistant", Difficulty = Difficulty.Media, MinSalary = 11500, MaxSalary = 13000 },
                new Job { JobTitle = "Shipping Clerk", Difficulty = Difficulty.Baja, MinSalary = 8500, MaxSalary = 10000 },
                new Job { JobTitle = "Packer", Difficulty = Difficulty.Baja, MinSalary = 8000, MaxSalary = 10000 },
                new Job { JobTitle = "Programer", Difficulty = Difficulty.Alta, MinSalary = 21400, MaxSalary = 26000 },
                new Job { JobTitle = "Database Administrator", Difficulty = Difficulty.Alta, MinSalary = 24500, MaxSalary = 30000 },
                new Job { JobTitle = "Account Manager", Difficulty = Difficulty.Alta, MinSalary = 12300, MaxSalary = 15000 },
                new Job { JobTitle = "Sales Operations Manager", Difficulty = Difficulty.Media, MinSalary = 13000, MaxSalary = 14000 },
                new Job { JobTitle = "Account Executive", Difficulty = Difficulty.Alta, MinSalary = 9700, MaxSalary = 12000 },
                new Job { JobTitle = "Executive HouseKeeper", Difficulty = Difficulty.Media, MinSalary = 10500, MaxSalary = 16000 },
                new Job { JobTitle = "Accounting Manager", Difficulty = Difficulty.Alta, MinSalary = 13500, MaxSalary = 16000 },
                new Job { JobTitle = "Accounting Assistant", Difficulty = Difficulty.Media, MinSalary = 11000, MaxSalary = 12500 },
                new Job { JobTitle = "Contracting Manager", Difficulty = Difficulty.Alta, MinSalary = 12500, MaxSalary = 14000 }
            };

            foreach (Job j in jobs)
            {
                context.Jobs.Add(j);
            }
            context.SaveChanges();
        
        //Employee
            var employees = new Employee[]
            {
                new Employee { FirstName = "Diana", LastName = "Escareño", Email = "dianaE@gmail.com", PhoneNumber = "492 651 8971", 
                    HireDate = DateTime.Parse("2015-03-23"), Salary = 19000, CommissionPCT = 200, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Administration-MX").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Administrative Coordinator").JobID },
                new Employee { FirstName = "Ernesto", LastName = "Valle", Email = "ernestoV@gmail.com", PhoneNumber = null, 
                    HireDate = DateTime.Parse("2001-01-23"), Salary = 12000, CommissionPCT = 1000, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Marketing-MX").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Marketing Assistant").JobID },
                new Employee { FirstName = "Cecilia", LastName = "Ramirez", Email = "ceciliaR@gmail.com", PhoneNumber = "493 652 8980", 
                    HireDate = DateTime.Parse("2008-12-12"), Salary = 9300, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Shipping-MX").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Shipping Clerk").JobID },
                new Employee { FirstName = "Alejandro", LastName = "Garcia", Email = "alejandroG@gmail.com", PhoneNumber = "492 298 6781", 
                    HireDate = DateTime.Parse("2018-07-12"), Salary = 29000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "IT-MX").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Database Administrator").JobID },
                new Employee { FirstName = "Steven", LastName = "King", Email = "stevenK@gmail.com", PhoneNumber = "515 897 9811", 
                    HireDate = DateTime.Parse("2002-11-09"), Salary = 23000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "IT-GB").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Programer").JobID },
                new Employee { FirstName = "Pat", LastName = "Fay", Email = "patF@gmail.com", PhoneNumber = null, 
                    HireDate = DateTime.Parse("2000-02-27"), Salary = 12600, CommissionPCT = 300, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Marketing-AU").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Marketing Assistant").JobID },
                new Employee { FirstName = "Michael", LastName = "Taylor", Email = "michaelT@gmail.com", PhoneNumber = "870 726 1023", 
                    HireDate = DateTime.Parse("2002-05-21"), Salary = 14000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Sales-AU").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Account Manager").JobID },
                new Employee { FirstName = "Kimberely", LastName = "Grant", Email = "kimberelyG@gmail.com", PhoneNumber = "650 192 8972", 
                    HireDate = DateTime.Parse("2010-02-17"), Salary = 17100, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Administration-US").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Administrative Coordinator").JobID },
                new Employee { FirstName = "Randall", LastName = "Matos", Email = "randallM@gmail.com", PhoneNumber = null, 
                    HireDate = DateTime.Parse("2019-04-11"), Salary = 9200, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Shipping-US").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Packer").JobID },
                new Employee { FirstName = "Shelley", LastName = "Higgins", Email = "shelleyH@gmail.com", PhoneNumber = "653 989 6620", 
                    HireDate = DateTime.Parse("2011-12-09"), Salary = 25000, CommissionPCT = 500, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "IT-US").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Programer").JobID },
                new Employee { FirstName = "Bruce", LastName = "Ernst", Email = "bruceE@gmail.com", PhoneNumber = "653 103 7790", 
                    HireDate = DateTime.Parse("2019-07-20"), Salary = 13300, CommissionPCT = 250, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Sales-US").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Sales Operations Manager").JobID },
                new Employee { FirstName = "Yuang", LastName = "Lee", Email = "yuangL@gmail.com", PhoneNumber = "011 597 4982", 
                    HireDate = DateTime.Parse("2003-06-27"), Salary = 24000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Administration-CN").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Administrative Director").JobID },
                new Employee { FirstName = "Kiyoshi", LastName = "Suzuki", Email = "kiroshiS@gmail.com", PhoneNumber = "010 653 2983", 
                    HireDate = DateTime.Parse("2017-08-18"), Salary = 11800, CommissionPCT = 100, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Marketing-JP").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Marketing Assistant").JobID },
                new Employee { FirstName = "Yumi", LastName = "Tanaka", Email = "yumiT@gmail.com", PhoneNumber = "011 784 6202", 
                    HireDate = DateTime.Parse("2015-10-01"), Salary = 11400, CommissionPCT = 800, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Executive-JP").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Account Executive").JobID },
                new Employee { FirstName = "Bruno", LastName = "Pereira", Email = "brunoP@gmail.com", PhoneNumber = "612 208 7710", 
                    HireDate = DateTime.Parse("2018-09-30"), Salary = 13000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Executive-PT").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Executive HouseKeeper").JobID },
                new Employee { FirstName = "Mohammed", LastName = "Fekir", Email = "mohammedF@gmail.com", PhoneNumber = null, 
                    HireDate = DateTime.Parse("2014-03-16"), Salary = 13600, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Sales-EG").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Sales Operations Manager").JobID },
                new Employee { FirstName = "Trenna", LastName = "Rajs", Email = "trennaR@gmail.com", PhoneNumber = "890 516 1200", 
                    HireDate = DateTime.Parse("2016-09-22"), Salary = 15000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Accounting-SN").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Accounting Manager").JobID },
                new Employee { FirstName = "Ismala", LastName = "Sar", Email = "ismalaS@gmail.com", PhoneNumber = "890 109 8762", 
                    HireDate = DateTime.Parse("2020-01-26"), Salary = 9000, CommissionPCT = 600, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Shipping-SN").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Shipping Clerk").JobID },
                new Employee { FirstName = "Kalidou", LastName = "Kouassi", Email = "kalidouK@gmail.com", PhoneNumber = "890 329 7168", 
                    HireDate = DateTime.Parse("2018-05-19"), Salary = 13000, CommissionPCT = null, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Executive-SN").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Executive HouseKeeper").JobID },
                new Employee { FirstName = "Brenda", LastName = "Guzman", Email = null, PhoneNumber = "489 200 8122", 
                    HireDate = DateTime.Parse("2016-04-25"), Salary = 12500, CommissionPCT = 400, 
                    DepartmentID = departments.Single( c => c.DepartmentName == "Contracting-MX").DepartmentID,
                    JobID = jobs.Single( i => i.JobTitle == "Contracting Manager").JobID }
            };

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

        //JobHistory
            var jobhistories = new JobHistory[]
            {
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Diana").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Administrative Assistant" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Administration-MX").DepartmentID,
                    StartDate = DateTime.Parse("2010-02-16"), EndDate = DateTime.Parse("2015-03-23")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Diana").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Administrative Coordinator" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Administration-MX").DepartmentID,
                    StartDate = DateTime.Parse("2015-03-23"), EndDate = DateTime.Parse("2021-03-23")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Ernesto").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Marketing Assistant" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Marketing-MX").DepartmentID,
                    StartDate = DateTime.Parse("2001-01-23"), EndDate = DateTime.Parse("2022-01-23")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Cecilia").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Shipping Clerk" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Shipping-MX").DepartmentID,
                    StartDate = DateTime.Parse("2008-12-12"), EndDate = DateTime.Parse("2020-12-12")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Alejandro").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Programer" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "IT-MX").DepartmentID,
                    StartDate = DateTime.Parse("2015-02-24"), EndDate = DateTime.Parse("2018-07-12")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Alejandro").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Database Administrator" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "IT-MX").DepartmentID,
                    StartDate = DateTime.Parse("2018-07-12"), EndDate = DateTime.Parse("2023-07-12")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Steven").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Programer" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "IT-GB").DepartmentID,
                    StartDate = DateTime.Parse("2002-11-09"), EndDate = DateTime.Parse("2020-11-09")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Pat").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Marketing Assistant" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Marketing-AU").DepartmentID,
                    StartDate = DateTime.Parse("2000-02-27"), EndDate = DateTime.Parse("2022-02-27")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Michael").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Account Manager" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Sales-AU").DepartmentID,
                    StartDate = DateTime.Parse("2002-05-21"), EndDate = DateTime.Parse("2021-05-21")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Kimberely").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Administrative Coordinator" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Administration-US").DepartmentID,
                    StartDate = DateTime.Parse("2010-02-17"), EndDate = DateTime.Parse("2022-02-17")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Randall").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Packer" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Shipping-US").DepartmentID,
                    StartDate = DateTime.Parse("2019-04-11"), EndDate = DateTime.Parse("2024-04-11")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Shelley").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Programer" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "IT-US").DepartmentID,
                    StartDate = DateTime.Parse("2011-12-09"), EndDate = DateTime.Parse("2021-12-09")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Bruce").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Sales Operations Manager" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Sales-US").DepartmentID,
                    StartDate = DateTime.Parse("2019-07-20"), EndDate = DateTime.Parse("2023-07-20")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Yuang").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Administrative Director" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Administration-CN").DepartmentID,
                    StartDate = DateTime.Parse("2003-06-27"), EndDate = DateTime.Parse("2023-06-27")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Kiyoshi").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Marketing Assistant" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Marketing-JP").DepartmentID,
                    StartDate = DateTime.Parse("2017-08-18"), EndDate = DateTime.Parse("2021-08-18")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Yumi").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Account Executive" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Executive-JP").DepartmentID,
                    StartDate = DateTime.Parse("2015-10-01"), EndDate = DateTime.Parse("2021-10-01")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Bruno").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Account Executive" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Executive-PT").DepartmentID,
                    StartDate = DateTime.Parse("2010-08-29"), EndDate = DateTime.Parse("2018-09-30")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Bruno").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Executive HouseKeeper" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Executive-PT").DepartmentID,
                    StartDate = DateTime.Parse("2018-09-30"), EndDate = DateTime.Parse("2023-09-30")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Mohammed").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Sales Operations Manager" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Sales-EG").DepartmentID,
                    StartDate = DateTime.Parse("2014-03-16"), EndDate = DateTime.Parse("2021-03-16")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Trenna").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Accounting Manager" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Accounting-SN").DepartmentID,
                    StartDate = DateTime.Parse("2016-09-22"), EndDate = DateTime.Parse("2021-09-22")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Ismala").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Packer" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Shipping-SN").DepartmentID,
                    StartDate = DateTime.Parse("2018-03-21"), EndDate = DateTime.Parse("2020-01-26")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Ismala").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Shipping Clerk" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Shipping-SN").DepartmentID,
                    StartDate = DateTime.Parse("2020-01-26"), EndDate = DateTime.Parse("2025-01-26")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Kalidou").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Executive HouseKeeper" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Executive-SN").DepartmentID,
                    StartDate = DateTime.Parse("2018-05-19"), EndDate = DateTime.Parse("2023-05-19")
                },
                new JobHistory {
                    EmployeeID = employees.Single(s => s.FirstName == "Brenda").EmployeeID,
                    JobID = jobs.Single(c => c.JobTitle == "Contracting Manager" ).JobID,
                    DepartmentID = departments.Single(i => i.DepartmentName == "Contracting-MX").DepartmentID,
                    StartDate = DateTime.Parse("2016-04-25"), EndDate = DateTime.Parse("2021-04-25")
                }
            };

            foreach (JobHistory jh in jobhistories)
            {
                var jobhistoryInDataBase = context.JobHistories.Where(
                    s =>
                            s.Employee.EmployeeID == jh.EmployeeID &&
                            s.Job.JobID == jh.JobID &&
                            s.Department.DepartmentID == jh.DepartmentID).SingleOrDefault();
                if (jobhistoryInDataBase == null)
                {
                    context.JobHistories.Add(jh);
                }
            }
            context.SaveChanges();
        }
    }
}