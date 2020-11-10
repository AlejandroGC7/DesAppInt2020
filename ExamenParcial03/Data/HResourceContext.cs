using HumanResourcesAGC.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesAGC.Data
{
    public class HResourceContext : DbContext
    {
        public HResourceContext(DbContextOptions<HResourceContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries {get; set;}
        public DbSet<Department> Departments {get; set;}
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Job> Jobs {get; set;}
        public DbSet<JobHistory> JobHistories {get; set;}
        public DbSet<Location> Locations {get; set;}
        public DbSet<Region> Regions {get; set;}
        
        //API Fluida
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<JobHistory>().ToTable("JobHistory");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Region>().ToTable("Region");

            modelBuilder.Entity<JobHistory>().HasKey(j => new {j.EmployeeID, j.JobID, j.DepartmentID});
        }

    }
}