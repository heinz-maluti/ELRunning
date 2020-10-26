using Microsoft.AspNetCore.Identity;
using SQLitePCL;
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

        public AppUser()
        {
            CountryID = new Guid("BEAF367C-15D5-4C04-A801-871E28E33086");
            GenderID = new Guid("FF735D70-90D4-4029-82D5-924C0FC58FA0");
        }

        public virtual List<ActivityLog> Logs { get; set; }

    }
}