using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;
using Microsoft.Extensions.Configuration.FileExtensions;

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

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WikiContext>
        {
            public WikiContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../wikibellum.Api/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<WikiContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new WikiContext(builder.Options);
            }
        }

    }
}
