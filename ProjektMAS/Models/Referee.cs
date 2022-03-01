using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class Referee : Person
    {
        public int RefereeID { get; set; }
        public int RefereeCardID { get; set; }
        public virtual ICollection<Match> Matches { get; set; }

    }
}
