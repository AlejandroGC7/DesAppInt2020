using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesAGC.Models
{
    public enum Difficulty {
        Alta, Media, Baja
    }
    public class Job{
        [Key]
        public int JobID {get; set;}
        [Required]
        [Display(Name="Job Title")]
        [StringLength(50)]
        public string JobTitle {get; set;}
        [Required]
        public Difficulty Difficulty {get; set;}
        [Required]
        [Display(Name="Minimum Salary")]
        [DataType(DataType.Currency)]
        [Column(TypeName="MinimumSalary")]
        public decimal MinSalary {get; set;}
        [Required]
        [Display(Name="Maximum Salary")]
        [DataType(DataType.Currency)]
        [Column(TypeName="MaximumSalary")]
        public decimal MaxSalary {get; set;}

        //Relación uno a muchos con las tablas JobHistory y Employee
        public ICollection<JobHistory> JobHistories {get; set;}
        public ICollection<Employee> Employees {get; set;}
    }
}