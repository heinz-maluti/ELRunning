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
        public Country Country { get; set; }
        public Gender Gender { get; set; }

        public virtual List<ActivityLog> Logs { get; set; }
    }

    public enum Country
    {
        ZA,
        USA,
        UK
    }

    public enum Gender
    {
        Male,
        Female
    }
}