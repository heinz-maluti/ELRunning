using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELRunning.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public Guid CountryID { get; set; }
        public Guid GenderID { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }

        public virtual List<ActivityLog> Logs { get; set; }

    }
}