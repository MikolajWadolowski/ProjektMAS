using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektMAS.Models;

namespace ProjektMAS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MasContext context)
        {

           // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Addresses.Any())
            {
                return;   // DB has been seeded
            }

         

            var addresses = new Address[]
            {
            
           // new Address{StreetNumber=4,StreetName="Klonowa",City="Ciechanów",PostalCode="06-400"},
            //new Address{StreetNumber=14,StreetName="Lipowa",City="Ciechanów",PostalCode="06-400"},
           //  new Address{StreetNumber=34,StreetName="Nadrzeczna",City="Ciechanów",PostalCode="06-400"}


            };
            foreach (Address e in addresses)
            {
                context.Addresses.Add(e);
            }
            context.SaveChanges();

        }
    }
}