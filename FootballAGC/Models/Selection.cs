using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballAGC.Models
{
    public class Selection{
        [Key]
        public int SelectionID {get; set;}
        [Required]
        [Display(Name="Selection")]
        [StringLength(50)]
        public string SelectionName {get; set;}

        //Relación uno a muchos con la tabla Player
        public ICollection<Player> Players {get; set;}
    }
}