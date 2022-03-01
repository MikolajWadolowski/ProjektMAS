using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class Traning
    {
        public int TraningID { get; set; }
        public DateTime DateSince { get; set; }
        public DateTime DataUntill { get; set; }
        public int MatchHallID { get; set; }
        public MatchHall MatchHall { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public Team Team { get; set; }
        public int TeamID { get; set; }

    }
}
