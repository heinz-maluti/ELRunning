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
    }

    public class Gender
    {
        public Guid GenderID { get; set; }
        public string GenderName { get; set; }

    }
}
