using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class ViewModelTeam
    {
        public IEnumerable<Match> AllMatches { get; set; }
        public Team ThisTeam { get; set; }
    }
}
