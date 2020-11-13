using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FootballAGC.Models;

namespace FootballAGC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FootballContext context)
        {
            context.Database.EnsureCreated();

            // Look for any teams.
            if (context.Teams.Any())
            {
                return;   // DB has been seeded
            }

        //Team
            var teams = new Team[]
            {
                new Team { TeamName = "Real Madrid FC" },
                new Team { TeamName = "FC Barcelona" },
                new Team { TeamName = "Atletico Madrid FC" },
                new Team { TeamName = "FC Bayern Munich" },
                new Team { TeamName = "Borussia Dortmund FC" },
                new Team { TeamName = "Juventus FC" },
                new Team { TeamName = "Inter Milan FC" },
                new Team { TeamName = "Club America" },
                new Team { TeamName = "Club Universidad Nacional" },
                new Team { TeamName = "Paris Saint-Germain FC" },
                new Team { TeamName = "Ajax FC" },
                new Team { TeamName = "Manchester United FC" },
                new Team { TeamName = "Chelsea FC" },
                new Team { TeamName = "Liverpool FC" },
                new Team { TeamName = "Benfica FC" }
            };

            foreach (Team t in teams)
            {
                context.Teams.Add(t);
            }
            context.SaveChanges();

        //Selection
            var selections = new Selection[]
            {
                new Selection { SelectionName = "Does not play in selection" },
                new Selection { SelectionName = "Seleccion España" },
                new Selection { SelectionName = "Seleccion Francia" },
                new Selection { SelectionName = "Seleccion Inglaterra" },
                new Selection { SelectionName = "Seleccion Alemania" },
                new Selection { SelectionName = "Seleccion Portugal" },
                new Selection { SelectionName = "Seleccion Italia" },
                new Selection { SelectionName = "Seleccion Belgica" },
                new Selection { SelectionName = "Seleccion Noruega" },
                new Selection { SelectionName = "Seleccion Brasil" },
                new Selection { SelectionName = "Seleccion Mexico" },
                new Selection { SelectionName = "Seleccion Estados Unidos" },
                new Selection { SelectionName = "Seleccion Argentina" },
                new Selection { SelectionName = "Seleccion Uruguay" },
                new Selection { SelectionName = "Seleccion Senegal" },
                new Selection { SelectionName = "Seleccion Egipto" },
                new Selection { SelectionName = "Seleccion Japon" }
            };

            foreach (Selection s in selections)
            {
                context.Selections.Add(s);
            }
            context.SaveChanges();

        //PlayerPosition
            var playerpositions = new PlayerPosition[]
            {
                new PlayerPosition { Position = Position.PO, PositionDescription = "Portero" },
                new PlayerPosition { Position = Position.DFC, PositionDescription = "Defensa Central" },
                new PlayerPosition { Position = Position.DFI, PositionDescription = "Defensa Central Izquierdo" },
                new PlayerPosition { Position = Position.DFD, PositionDescription = "Defensa Central Derecho" },
                new PlayerPosition { Position = Position.MCD, PositionDescription = "Medio Central Defensivo" },
                new PlayerPosition { Position = Position.MC, PositionDescription = "Medio Central" },
                new PlayerPosition { Position = Position.MI, PositionDescription = "Medio Izquierdo" },
                new PlayerPosition { Position = Position.MD, PositionDescription = "Medio Derecho" },
                new PlayerPosition { Position = Position.MCO, PositionDescription = "Medio Central Ofensivo" },
                new PlayerPosition { Position = Position.MP, PositionDescription = "Medio Punta" },
                new PlayerPosition { Position = Position.EI, PositionDescription = "Extremo Izquierdo" },
                new PlayerPosition { Position = Position.ED, PositionDescription = "Extremo Derecho" },
                new PlayerPosition { Position = Position.DC, PositionDescription = "Centro Delantero" }                
            };

            foreach (PlayerPosition pp in playerpositions)
            {
                context.PlayerPositions.Add(pp);
            }
            context.SaveChanges();

        //Player
            var players = new Player[]
            {
                new Player { TeamID = teams.Single( i => i.TeamName == "Real Madrid FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion España" ).SelectionID,
                    FirstName = "Sergio", LastName = "Ramos", PlayerSquadNumber = 4,  PlayerBirthdate = DateTime.Parse("1986-03-30"), PlayerNationality = "España", PlayerValue = 31500000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Defensa Central" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Real Madrid FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Belgica" ).SelectionID,
                    FirstName = "Eden", LastName = "Hazard", PlayerSquadNumber = 7,  PlayerBirthdate = DateTime.Parse("1991-01-07"), PlayerNationality = "Belgica", PlayerValue = 90000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Extremo Izquierdo" ).PlayerPositionID },
                
                new Player { TeamID = teams.Single( i => i.TeamName == "FC Barcelona" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Argentina" ).SelectionID,
                    FirstName = "Lionel", LastName = "Messi", PlayerSquadNumber = 10,  PlayerBirthdate = DateTime.Parse("1987-06-24"), PlayerNationality = "Argentina", PlayerValue = 95500000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Medio Central Ofensivo" ).PlayerPositionID },
                
                new Player { TeamID = teams.Single( i => i.TeamName == "Atletico Madrid FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Portugal" ).SelectionID,
                    FirstName = "Joao", LastName = "Felix", PlayerSquadNumber = 7,  PlayerBirthdate = DateTime.Parse("1999-11-10"), PlayerNationality = "Portugal", PlayerValue = 80000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Medio Punta" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "FC Bayern Munich" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Alemania" ).SelectionID,
                    FirstName = "Leroy", LastName = "Sane", PlayerSquadNumber = 10,  PlayerBirthdate = DateTime.Parse("1996-01-11"), PlayerNationality = "Alemania", PlayerValue = 70000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Extremo Izquierdo" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Borussia Dortmund FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Noruega" ).SelectionID,
                    FirstName = "Erling", LastName = "Haaland", PlayerSquadNumber = 9,  PlayerBirthdate = DateTime.Parse("2000-07-21"), PlayerNationality = "Noruega", PlayerValue = 80000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Centro Delantero" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Juventus FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Portugal" ).SelectionID,
                    FirstName = "Cristiano Ronaldo", LastName = "Dos Santos", PlayerSquadNumber = 7,  PlayerBirthdate = DateTime.Parse("1985-02-05"), PlayerNationality = "Portugal", PlayerValue = 60000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Extremo Izquierdo" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Club America" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Mexico" ).SelectionID,
                    FirstName = "Guillermo", LastName = "Ochoa", PlayerSquadNumber = 1,  PlayerBirthdate = DateTime.Parse("1985-07-13"), PlayerNationality = "Mexico", PlayerValue = 2000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Portero" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Club Universidad Nacional" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Argentina" ).SelectionID,
                    FirstName = "Juan Ignacio", LastName = "Dinenno", PlayerSquadNumber = 9,  PlayerBirthdate = DateTime.Parse("1994-08-28"), PlayerNationality = "Argentina", PlayerValue = 2500000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Centro Delantero" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Paris Saint-Germain FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Brasil" ).SelectionID,
                    FirstName = "Neymar", LastName = "Santos", PlayerSquadNumber = 10,  PlayerBirthdate = DateTime.Parse("1992-02-05"), PlayerNationality = "Brasil", PlayerValue = 128000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Extremo Izquierdo" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Paris Saint-Germain FC" ).TeamID,
                    SelectionID  = selections.Single( i => i.SelectionName == "Seleccion Italia" ).SelectionID,
                    FirstName = "Marco", LastName = "Verratti", PlayerSquadNumber = 8,  PlayerBirthdate = DateTime.Parse("1992-11-05"), PlayerNationality = "Italia", PlayerValue = 60000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Medio Central Defensivo" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Manchester United FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Francia" ).SelectionID,
                    FirstName = "Paul", LastName = "Pogba", PlayerSquadNumber = 6,  PlayerBirthdate = DateTime.Parse("1993-03-05"), PlayerNationality = "Francia", PlayerValue = 80000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Medio Central" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Chelsea FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Inglaterra" ).SelectionID,
                    FirstName = "Reece", LastName = "James", PlayerSquadNumber = 24,  PlayerBirthdate = DateTime.Parse("1999-12-08"), PlayerNationality = "Inglaterra", PlayerValue = 30000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Defensa Central Derecho" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Liverpool FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Senegal" ).SelectionID,
                    FirstName = "Sadio", LastName = "Mane", PlayerSquadNumber = 10,  PlayerBirthdate = DateTime.Parse("1992-04-10"), PlayerNationality = "Senegal", PlayerValue = 120000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Extremo Izquierdo" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Liverpool FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Egipto" ).SelectionID,
                    FirstName = "Mohamed", LastName = "Salah", PlayerSquadNumber = 11,  PlayerBirthdate = DateTime.Parse("1992-06-15"), PlayerNationality = "Egipto", PlayerValue = 120000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Extremo Derecho" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Benfica FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion España" ).SelectionID,
                    FirstName = "Alejandro", LastName = "Grimaldo", PlayerSquadNumber = 3,  PlayerBirthdate = DateTime.Parse("1995-09-20"), PlayerNationality = "España", PlayerValue = 28000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Defensa Central Izquierdo" ).PlayerPositionID },

                new Player { TeamID = teams.Single( i => i.TeamName == "Benfica FC" ).TeamID,
                    SelectionID = selections.Single( i => i.SelectionName == "Seleccion Brasil" ).SelectionID,
                    FirstName = "Everton", LastName = "Sousa", PlayerSquadNumber = 7,  PlayerBirthdate = DateTime.Parse("1996-03-22"), PlayerNationality = "Brasil", PlayerValue = 25000000, 
                    PlayerPositionID = playerpositions.Single( i => i.PositionDescription == "Medio Izquierdo" ).PlayerPositionID }                         
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);
            }
            context.SaveChanges();
        
        //Competition
            var competitions = new Competition[]
            {
                new Competition { CompetitionID = 1, CompetitionName = "La Liga (España)" },
                new Competition { CompetitionID = 2, CompetitionName = "Bundesliga 1 (Alemania)" },
                new Competition { CompetitionID = 3, CompetitionName = "Serie A (Italia)" },
                new Competition { CompetitionID = 4, CompetitionName = "Liga BBVA (Mexico)" },
                new Competition { CompetitionID = 5, CompetitionName = "MLS (Estados Unidos)" },
                new Competition { CompetitionID = 6, CompetitionName = "Ligue 1 (Francia)" },
                new Competition { CompetitionID = 7, CompetitionName = "Eredivisie (Holanda)" },
                new Competition { CompetitionID = 8, CompetitionName = "Premiere League (Inglaterra)" },
                new Competition { CompetitionID = 9, CompetitionName = "Primeira Liga (Portugal)" },
                new Competition { CompetitionID = 10, CompetitionName = "UEFA Europa League (Europa)" },
                new Competition { CompetitionID = 11, CompetitionName = "UEFA Champions League (Europa)" },
                new Competition { CompetitionID = 12, CompetitionName = "Mundial de Clubes (Internacional)" }
            };

            foreach (Competition c in competitions)
            {
                context.Competitions.Add(c);
            }
            context.SaveChanges();

        //Fixture
            var fixtures = new Fixture[]
            {
                new Fixture { FixtureDescription = "G1-J1-España", FixtureDate = DateTime.Parse("2019-02-21"), FixtureTime = DateTime.Parse("08:45:00 am"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Real Madrid FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "FC Barcelona").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "La Liga (España)").CompetitionID
                },
                new Fixture { FixtureDescription = "G2-J3-España", FixtureDate = DateTime.Parse("2019-03-01"), FixtureTime = DateTime.Parse("05:30:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Atletico Madrid FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Real Madrid FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "La Liga (España)").CompetitionID
                },
                new Fixture { FixtureDescription = "G4-J3-Alemania", FixtureDate = DateTime.Parse("2019-03-22"), FixtureTime = DateTime.Parse("09:00:00 am"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "FC Bayern Munich").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Borussia Dortmund FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "Bundesliga 1 (Alemania)").CompetitionID
                },
                new Fixture { FixtureDescription = "G7-J4-Italia", FixtureDate = DateTime.Parse("2019-04-17"), FixtureTime = DateTime.Parse("06:50:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Juventus FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Inter Milan FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "Serie A (Italia)").CompetitionID
                },
                new Fixture { FixtureDescription = "G2-J6-Mexico", FixtureDate = DateTime.Parse("2019-04-30"), FixtureTime = DateTime.Parse("07:45:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Club America").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Club Universidad Nacional").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "Liga BBVA (Mexico)").CompetitionID
                },
                new Fixture { FixtureDescription = "G1-J1-UCL", FixtureDate = DateTime.Parse("2019-05-02"), FixtureTime = DateTime.Parse("01:45:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "FC Barcelona").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Paris Saint-Germain FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "UEFA Champions League (Europa)").CompetitionID
                },
                new Fixture { FixtureDescription = "G2-J1-UCL", FixtureDate = DateTime.Parse("2019-05-03"), FixtureTime = DateTime.Parse("01:45:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Liverpool FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Manchester United FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "UEFA Champions League (Europa)").CompetitionID
                },
                new Fixture { FixtureDescription = "G3-J5-Inglaterra", FixtureDate = DateTime.Parse("2019-06-10"), FixtureTime = DateTime.Parse("08:15:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Manchester United FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Chelsea FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "Premiere League (Inglaterra)").CompetitionID
                },
                new Fixture { FixtureDescription = "G1-J2-UEL", FixtureDate = DateTime.Parse("2019-08-22"), FixtureTime = DateTime.Parse("10:30:00 am"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Benfica FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Chelsea FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "UEFA Europa League (Europa)").CompetitionID
                },
                new Fixture { FixtureDescription = "G2-J2-UCL", FixtureDate = DateTime.Parse("2019-10-09"), FixtureTime = DateTime.Parse("01:45:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Juventus FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Paris Saint-Germain FC").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "UEFA Champions League (Europa)").CompetitionID
                },
                new Fixture { FixtureDescription = "G5-J2-UCL", FixtureDate = DateTime.Parse("2019-10-10"), FixtureTime = DateTime.Parse("01:45:00 pm"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Real Madrid FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "FC Bayern Munich").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "UEFA Champions League (Europa)").CompetitionID
                },
                new Fixture { FixtureDescription = "G1-J1-Mundial", FixtureDate = DateTime.Parse("2019-12-16"), FixtureTime = DateTime.Parse("10:15:00 am"), 
                    HomeTeamID = teams.Single( s => s.TeamName == "Manchester United FC").TeamID,
                    AwayTeamID = teams.Single( c => c.TeamName == "Club America").TeamID,
                    CompetitionID = competitions.Single( i => i.CompetitionName == "Mundial de Clubes (Internacional)").CompetitionID
                }
            };

            foreach (Fixture f in fixtures)
            {
                context.Fixtures.Add(f);
            }
            context.SaveChanges();

        //PlayerFixture
            var playerfixtures = new PlayerFixture[]
            {
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-España").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Ramos" ).PlayerID,
                    GoalsScored = 0
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-España").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Hazard" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-España").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Messi" ).PlayerID,
                    GoalsScored = 1
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J3-España" ).FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Felix" ).PlayerID,
                    GoalsScored = 3
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G4-J3-Alemania").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Sane" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G4-J3-Alemania").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Haaland" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G7-J4-Italia").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Dos Santos" ).PlayerID,
                    GoalsScored = 3
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J6-Mexico").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Ochoa" ).PlayerID,
                    GoalsScored = 0
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Messi" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Santos" ).PlayerID,
                    GoalsScored = 1
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J1-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Salah" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J1-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Mane" ).PlayerID,
                    GoalsScored = 1
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G3-J5-Inglaterra").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "James" ).PlayerID,
                    GoalsScored = 0
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J2-UEL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Sousa" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J2-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Dos Santos" ).PlayerID,
                    GoalsScored = 4
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J2-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Santos" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G2-J2-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Verratti" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G5-J2-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Hazard" ).PlayerID,
                    GoalsScored = 2
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G5-J2-UCL").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Sane" ).PlayerID,
                    GoalsScored = 1
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-Mundial").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Pogba" ).PlayerID,
                    GoalsScored = 1
                },
                new PlayerFixture {
                    FixtureID = fixtures.Single(s => s.FixtureDescription == "G1-J1-Mundial").FixtureID,
                    PlayerID = players.Single(c => c.LastName == "Ochoa" ).PlayerID,
                    GoalsScored = 2
                }
            };

            foreach (PlayerFixture pf in playerfixtures)
            {
                var playerfixtureInDataBase = context.PlayerFixtures.Where(
                    x =>
                            x.Fixture.FixtureID == pf.FixtureID &&
                            x.Player.PlayerID == pf.PlayerID).SingleOrDefault();
                if (playerfixtureInDataBase == null)
                {
                    context.PlayerFixtures.Add(pf);
                }
            }
            context.SaveChanges();
        }
    }
}