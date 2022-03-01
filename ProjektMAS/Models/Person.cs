using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{

    public enum Lane
    {
        Mid,
        Top,
        Adc,
        Support,
        Jungle
    }

    public enum PersonType
    {
        Trainer,
        Player,
        Referee,
        Fan,
    }

    public enum Speciality
    {
        FormerPro,
        RenownedTrainer,
        FreshBlood
    }


    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Pesel { get; set; }
        public Address? Address { get; set; }
        public int? AddressID { get; set; }
        public PersonType? PersonType { get; set; }
        public int? Skill { get; set; }
        public int? Tenacity { get; set; }
        public Lane? Lane { get; set; }
        public int? RefereeCardID { get; set; }
        public int? Income { get; set; }
        public Speciality? Speciality { get; set; }
        public virtual ICollection<TeamPerson> TeamPeople { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
