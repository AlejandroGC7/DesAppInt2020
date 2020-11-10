using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HumanResourcesAGC.Models
{
    public class Location{
        [Key]
        public int LocationID {get; set;}
        [Required]
        [Display(Name="Street Address")]
        [StringLength(50)]
        public string StreetAddress {get; set;}
        [Required]
        [Display(Name="Postal Code")]
        [StringLength(20)]
        public string PostalCode {get; set;}
        [Required]
        [Display(Name="City")]
        [StringLength(30)]
        public string City {get; set;}
        [Required]
        [Display(Name="State Province")]
        [StringLength(30)]
        public string StateProvince {get; set;}
        public int CountryID {get; set;}

        //Relación uno a muchos con la tabla Department
        public ICollection<Department> Departments {get; set;}
        
        //Relación muchos a uno con la tabla Country
        public Country Country {get; set;}
    }
}