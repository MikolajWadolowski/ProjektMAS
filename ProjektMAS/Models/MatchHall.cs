using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjektMAS.Models
{
    public class MatchHall
    {
        public int MatchHallID { get; set; }
        public int SeatNumber { get; set; }
        public string HallName { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Traning> Tranings { get; set; }

    }
}
