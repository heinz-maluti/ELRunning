using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELRunning.Models
{
    public class Country
    {
        public Guid CountryID { get; set; }
        public string CountryName { get; set; }

        public Country()
        {
            CountryID = Guid.NewGuid();
        }

        public Country(Guid countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }
    }

    public class Gender
    {
        public Guid GenderID { get; set; }
        public string GenderName { get; set; }

        public Gender()
        {
            GenderID = Guid.NewGuid();
        }

        public Gender(Guid genderID, string genderName)
        {
            GenderID = genderID;
            GenderName = genderName;
        }
    }
}
