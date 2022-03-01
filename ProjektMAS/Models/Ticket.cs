using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int SeatNumber { get; set; }
        public Person Person { get; set; }
        public int PersonID { get; set; }
        public Match Match { get; set; }
        public int MatchID { get; set; }
    }
}
