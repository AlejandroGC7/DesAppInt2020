using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesAGC.Models
{
    public class Country{
        [Key]
        public int CountryID {get; set;}
        [Required]
        [Display(Name="ISO (alfa-2)")]
        [StringLength(2,MinimumLength=2)]
        public string ISO {get; set;}
        [Required]
        [Display(Name="Country")]
        [StringLength(30)]
        public string CountryName {get; set;}
        public int RegionID {get; set;}

        //Relación uno a muchos con la tabla Location
        public ICollection<Location> Locations {get; set;}

        //Relación muchos a uno con la tabla Region
        public Region Region {get; set;}
    }
}
