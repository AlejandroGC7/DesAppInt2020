using System;
using System.ComponentModel.DataAnnotations;

namespace HumanResourcesAGC.Models
{
    public class JobHistory{
        public int EmployeeID {get; set;}
        public int JobID {get; set;}
        public int DepartmentID {get; set;}
        [Required]
        [Display(Name="Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime StartDate {get; set;}
        [Required]
        [Display(Name="End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime EndDate {get; set;}

        //Relación muchos a uno con las tablas Department, Employee y Job
        public Department Department {get; set;}
        public Employee Employee {get; set;}
        public Job Job {get; set;}
    }
}