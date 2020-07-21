using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public class WikiContext : IdentityDbContext<IdentityUser>
    {
        public WikiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<UnitStrength> UnitStrengths { get; set; }
        public DbSet<UnitLosses> UnitLosses { get; set; }
    }
}
