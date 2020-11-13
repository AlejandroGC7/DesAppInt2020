using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballAGC.Models
{
    public enum Position{
        PO, DFC, DFI, DFD, LI, LD, MCD, MC, MI, MD, MCO, MP, EI, ED, DC, SDD, SDI
    }

    public class PlayerPosition{
        [Key]
        public int PlayerPositionID {get; set;}
        [Required]
        [Display(Name="Position")]
        public Position Position {get; set;}
        [Required]
        [Display(Name="Description")]
        [StringLength(50)]
        public string PositionDescription {get; set;}

        //Relación uno a muchos con la tabla Player
        public ICollection<Player> Players {get; set;}
    }
}