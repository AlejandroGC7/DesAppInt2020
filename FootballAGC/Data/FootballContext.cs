using FootballAGC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FootballAGC.Data
{
    public class FootballContext : IdentityDbContext<User>
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {
        }

        public DbSet<Competition> Competitions {get; set;}
        public DbSet<Fixture> Fixtures {get; set;}
        public DbSet<Player> Players {get; set;}
        public DbSet<PlayerFixture> PlayerFixtures {get; set;}
        public DbSet<PlayerPosition> PlayerPositions {get; set;}
        public DbSet<Selection> Selections {get; set;}
        public DbSet<Team> Teams {get; set;}
        
        //API Fluida
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Competition>().ToTable("Competition");
            modelBuilder.Entity<Fixture>().ToTable("Fixture");
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<PlayerFixture>().ToTable("PlayerFixture");
            modelBuilder.Entity<PlayerPosition>().ToTable("PlayerPosition");
            modelBuilder.Entity<Selection>().ToTable("Selection");
            modelBuilder.Entity<Team>().ToTable("Team");

            modelBuilder.Entity<PlayerFixture>().HasKey(p => new { p.FixtureID, p.PlayerID });
        }
    }
}