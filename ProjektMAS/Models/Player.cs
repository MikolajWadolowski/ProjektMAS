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

    public class Player : Person
    {
        public int PlayerID { get; set; }
        public int Skill { get; set; }
        public int Tenacity { get; set; }
        public Lane? Lane { get; set; }

        public Team Team { get; set; }
        public int TeamID { get; set; }

    }
}
