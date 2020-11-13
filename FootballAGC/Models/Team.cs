using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballAGC.Models
{
    public class Team{
        [Key]
        public int TeamID {get; set;}
        [Required]
        [Display(Name="Team")]
        [StringLength(50)]
        public string TeamName {get; set;}

        //Relación uno a muchos con la tabla Player
        public ICollection<Player> Players {get; set;}
    }
}