using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class PersonMatch
    {
        public int PersonMatchID { get; set; }
        public int PersonID { get; set; }
        public int MatchID { get; set; }
        public virtual Match Match { get; set; }
        public virtual Person Person { get; set; }

    }
}
