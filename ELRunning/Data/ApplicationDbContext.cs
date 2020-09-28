using System;
using System.Collections.Generic;
using System.Text;
using ELRunning.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELRunning.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ActivityEvent> ActivityEvents {get;set;}
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
    }
}