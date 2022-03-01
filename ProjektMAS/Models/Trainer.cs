using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{

    public enum Speciality
    {
        FormerPro,
        RenownedTrainer,
        FreshBlood
    }


    public class Trainer : Person
    {
       public int TrainerID { get; set; }
        public int Income { get; set; }
        public Speciality? Speciality { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

    }
}
