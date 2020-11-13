using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAGC.Models
{
    public class Competition{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Number")]
        public int CompetitionID {get; set;}
        [Required]
        [Display(Name="Competition Name")]
        [StringLength(50, MinimumLength=5)]
        public string CompetitionName {get; set;}
    
        //Relación uno a muchos con la tabla Fixture
        public ICollection<Fixture> Fixtures {get; set;}
    }
}