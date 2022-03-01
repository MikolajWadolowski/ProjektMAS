using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int TraningID { get; set; }
        public Traning Traning { get; set; }

    }
}
