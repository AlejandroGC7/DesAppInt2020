using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student{
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
        public DateTime EnrollmentDate {get; set;}
        [NotMapped]
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<Enrollment> Enrollments {get; set;}  //Uno a muchos con Enrrollments
    }
}