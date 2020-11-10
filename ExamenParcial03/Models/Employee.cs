using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesAGC.Models
{
    public class Employee{
        [Key]
        public int EmployeeID {get; set;}
        [Required]
        [Display(Name="First Name")]
        [StringLength(50)]
        public string FirstName {get; set;}
        [Required]
        [Display(Name="Last Name")]
        [StringLength(50)]
        public string LastName {get; set;}
        [Display(Name="E-mail")]
        [StringLength(50)]
        [DisplayFormat(NullDisplayText="No E-mail")]
        public string Email {get; set;}
        [Display(Name="Phone Number")]
        [StringLength(20,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Phone Number")]
        public string PhoneNumber {get; set;}
        [Required]
        [Display(Name="Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime HireDate {get; set;}
        [Required]
        [Display(Name="Salary")]
        [DataType(DataType.Currency)]
        public decimal Salary {get; set;}
        [Display(Name="Commission PCT")]
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText="No Commission PCT")]
        public decimal? CommissionPCT {get; set;}
        public int DepartmentID {get; set;}
        public int JobID {get; set;}
        [NotMapped]
        public string FullName => LastName + ", " + FirstName;

        //Relación uno a muchos con la tabla JobHistory
        public ICollection<JobHistory> JobHistories {get; set;}

        //Relación muchos a uno con las tablas Department y Job
        public Department Department {get; set;}
        public Job Job {get; set;}
    }
}