using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesAGC.Models
{
    public class Department{
        [Key]
        public int DepartmentID {get; set;}
        [Required]
        [Display(Name="Department")]
        [StringLength(30,MinimumLength=3)]
        public string DepartmentName {get; set;}
        public int LocationID {get; set;}

        //Relación uno a muchos con las tablas JobHistory y Employee
        public ICollection<JobHistory> JobHistories {get; set;}
        public ICollection<Employee> Employees {get; set;}

        //Relación muchos a uno con la tabla Location
        public Location Location {get; set;}
    }
}