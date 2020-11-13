using System;
using System.ComponentModel.DataAnnotations;

namespace FootballAGC.Models
{
    public class PlayerFixture{
        public int FixtureID {get; set;}
        public int PlayerID {get; set;}
        [Required]
        public int GoalsScored {get; set;}

        //Relacion muchos a uno con las tablas Player y Fixture
        public Player Player {get; set;}
        public Fixture Fixture {get; set;}
    }
}