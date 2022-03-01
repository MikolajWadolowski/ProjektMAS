using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektMAS.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public int MatchHallID { get; set; }
        public MatchHall MatchHall { get; set; }

    }
}
