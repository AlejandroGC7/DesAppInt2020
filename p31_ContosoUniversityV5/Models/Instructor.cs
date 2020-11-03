using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Instructor{
        [Key]
        public int ID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Last Name")]
        public string LastName {get; set;}
        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name="First Name")]
        public string FirstMidName {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime HireDate {get; set;}
        [NotMapped]
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<CourseAssignment> CourseAssignments {get; set;}
        public OfficeAssignment OfficeAssignment {get; set;}
    }
}