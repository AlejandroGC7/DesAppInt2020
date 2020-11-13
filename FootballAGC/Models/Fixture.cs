using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAGC.Models
{
    public class Fixture{
        [Key]
        public int FixtureID {get; set;}
        [Required]
        [Display(Name="Description")]
        [StringLength(50)]
        public string FixtureDescription {get; set;}
        [Required]
        [Display(Name="Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime FixtureDate {get; set;}
        [Required]
        [Display(Name="Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString="{0:hh:mm:ss tt}", ApplyFormatInEditMode=true)]
        public DateTime FixtureTime {get; set;}
        [Required]
        [Display(Name="Home Team")]
        public int HomeTeamID {get; set;}
        [Required]
        [Display(Name="Away Team")]
        public int AwayTeamID {get; set;}
        public int CompetitionID {get; set;}

        //Relación uno a muchos con la tabla PlayerFixture
        public ICollection<PlayerFixture> PlayerFixtures {get; set;}

        //Relacion muchos a uno con la tabla Competition y Team
        public Team HomeTeam {get; set;}
        public Team AwayTeam {get; set;}
        public Competition Competition {get; set;}
    }
}