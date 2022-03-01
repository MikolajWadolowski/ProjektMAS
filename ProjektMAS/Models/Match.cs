using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public enum Status
    {
        CREATED,
        ADDINGREFERE
    }

    public class Match
    {

        public int MatchID { get; set; }
        [Required]
        public int MatchHallID { get; set; }
        [Required]
        public int TeamID { get; set; }
        [Required]
        public virtual Team Team { get; set; }
        [Required]
        public virtual MatchHall Hall { get; set; }
        [Required]
        public string OpponentName { get; set; }
        public DateTime DataSince { get; set; }
        public DateTime DataUntill { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime DayofTheMatch { get; set; }
        public string Duration { get; set; }
        public Status? Status { get; set; }
        public virtual Person? Referee { get; set; }
        public int? PersonID { get; set; }
        public bool isActive { get; set; }
         public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
