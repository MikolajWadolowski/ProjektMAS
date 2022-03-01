using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public enum Region
{
    NA,
    SA,
    EUW,
    EUNE,
    AUS,
    ASIA
}


namespace ProjektMAS.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        
        [Column(TypeName="Date")]
        public DateTime CreationDate { get; set; }
        public string TeamName { get; set; }
        public Region? Region { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<TeamPerson> TeamPeople { get; set; }
        //  public virtual ICollection<Player> Players { get; set; }
         public virtual ICollection<Traning> Tranings { get; set; }
        // public int PersonID { get; set; }
        //  public Trainer Trainer { get; set; }

    }
}
