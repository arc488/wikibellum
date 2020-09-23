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
using wikibellum.Entities.Models.Units;
using wikibellum.Entities.Enums;
using Condition = wikibellum.Entities.Models.Units.Condition;
using wikibellum.Entities.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace wikibellum.Data
{
    public class WikiContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public WikiContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Result> Result { get; set; }

        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WikiContext>
        //{
        //    public WikiContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile(@Directory.GetCurrentDirectory() + "/../wikibellum.Api/appsettings.json")
        //            .Build();
        //        var builder = new DbContextOptionsBuilder<WikiContext>();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        builder.UseSqlServer(connectionString);
        //        return new WikiContext(builder.Options);
        //    }
        //}

    }
}
