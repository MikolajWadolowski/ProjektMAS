using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class Follower : Person
    {
        public int FanClubCardId { get; set; }
        public DateTime ClubJoinDate { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
