using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class ViewModelHall
    {
        public IEnumerable<Match> AllMatches { get; set; }

        public MatchHall ThisHall { get; set; }

    }
}
