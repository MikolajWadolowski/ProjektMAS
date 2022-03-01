using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class TeamPerson
    {
        public int TeamPersonID { get; set; }
        public int PersonID { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public virtual Person Person { get; set; }


    }
}
