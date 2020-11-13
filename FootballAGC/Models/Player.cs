using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAGC.Models
{
    public class Player{
        [Key]
        public int PlayerID {get; set;}
        public int TeamID {get; set;}
        public int SelectionID {get; set;}
        [Required]
        [Display(Name="First Name")]
        [StringLength(50)]
        public string FirstName {get; set;}
        [Required]
        [Display(Name="Last Name")]
        [StringLength(50)]
        public string LastName {get; set;}
        [Required]
        [Range(0,99)]
        [Display(Name="Squad Number")]
        public int PlayerSquadNumber {get; set;}
        [Required]
        [Display(Name="Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime PlayerBirthdate {get; set;}
        [Required]
        [Display(Name="Nationality")]
        [StringLength(50)]
        public string PlayerNationality {get; set;}
        [Required]
        [Display(Name="Value")]
        [DataType(DataType.Currency)]
        [Column(TypeName="Value")]
        public decimal PlayerValue {get; set;}
        public int PlayerPositionID {get; set;}

        [NotMapped]
        public string FullName => LastName + ", " + FirstName;

        //Relación uno a muchos con la tabla PlayerFixture
        public ICollection<PlayerFixture> PlayerFixtures {get; set;}

        //Relacion muchos a uno con las tablas Team, Selection y PlayerPosition
        public Team Team {get; set;}
        public Selection Selection {get; set;}
        public PlayerPosition PlayerPosition {get; set;}
    }
}