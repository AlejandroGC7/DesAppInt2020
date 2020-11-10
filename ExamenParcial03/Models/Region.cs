using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesAGC.Models
{
    public enum RegionName {
        Africa, Asia, Europa, Latinoamerica, Norteamerica, Sudamerica, Oceania, Otra
    }

    public class Region{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Number")]
        public int RegionID {get; set;}
        [Required]
        [Display(Name="Region")]
        [StringLength(30)]
        public RegionName RegionName {get; set;}

        //Relación uno a muchos con la tabla Country
        public ICollection<Country> Countries {get; set;}
    }
}