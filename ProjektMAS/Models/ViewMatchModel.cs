using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class ViewMatchModel
    {
        public List<MatchHall> AllHalls { get; set; }
        public List<Team> AllTeams { get; set; }
        public List<Match> AllMatches { get; set; }
    }
}
