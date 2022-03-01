using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektMAS.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjektMAS.Data
{
    public class MasContext : DbContext
    {
        public MasContext(DbContextOptions<MasContext> options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchHall> Halls { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Traning> Tranings { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coach> Couches { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Match>()
                   .HasOne(bc => bc.Referee)
                   .WithMany(b => b.Matches)
                   .HasForeignKey(bc => bc.PersonID)
                   .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Match>()
                    .HasOne(bc => bc.Team)
                    .WithMany(b => b.Matches)
                    .HasForeignKey(bc => bc.TeamID);

                modelBuilder.Entity<Match>()
                    .HasOne(bc => bc.Hall)
                    .WithMany(c => c.Matches)
                    .HasForeignKey(bc => bc.MatchHallID);
            }
            
            {

                modelBuilder.Entity<MatchHall>()
                   .HasOne<Address>(s => s.Address)
                   .WithOne(ad => ad.MatchHall)
                   .HasForeignKey<Address>(ad => ad.MatchHallID);
            }

            {

                modelBuilder.Entity<Address>()
                    .HasMany(c => c.People)
                    .WithOne(e => e.Address)
                    .HasForeignKey(bc => bc.AddressID);
            }



            {



                modelBuilder.Entity<TeamPerson>()
                    .HasOne(bc => bc.Team)
                    .WithMany(b => b.TeamPeople)
                    .HasForeignKey(bc => bc.TeamID);

                modelBuilder.Entity<TeamPerson>()
                    .HasOne(bc => bc.Person)
                    .WithMany(c => c.TeamPeople)
                    .HasForeignKey(bc => bc.PersonID);
            }



            {



                     modelBuilder.Entity<Traning>()
                    .HasOne(bc => bc.Team)
                    .WithMany(b => b.Tranings)
                    .HasForeignKey(bc => bc.TeamID);


                modelBuilder.Entity<Traning>()
                  .HasOne(bc => bc.MatchHall)
                  .WithMany(b => b.Tranings)
                  .HasForeignKey(bc => bc.MatchHallID);

           
            }

            {
                modelBuilder.Entity<Coach>()
                    .HasOne(bc => bc.Traning)
                    .WithMany(b => b.Coaches)
                    .HasForeignKey(bc => bc.TraningID);
            }

            {
                modelBuilder.Entity<Ticket>()
                      .HasOne(bc => bc.Person)
                      .WithMany(b => b.Tickets)
                      .HasForeignKey(bc => bc.PersonID)
                     .OnDelete(DeleteBehavior.Restrict);


                modelBuilder.Entity<Ticket>()
                      .HasOne(bc => bc.Match)
                      .WithMany(b => b.Tickets)
                      .HasForeignKey(bc => bc.MatchID)
                     .OnDelete(DeleteBehavior.Restrict);


            }

        }

        private void OnDelete(DeleteBehavior restrict)
        {
            throw new NotImplementedException();
        }
    }
}