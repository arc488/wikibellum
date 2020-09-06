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
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Alliance> Alliances { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //List<Branch> branches = new List<Branch>()
            //{
            //    new Branch()
            //    {
            //        BranchId = 1,
            //        Name = "Naval"
            //    },
            //    new Branch()
            //    {
            //        BranchId = 2,
            //        Name = "Air"
            //    },
            //    new Branch()
            //    {
            //        BranchId = 3,
            //        Name = "Land"
            //    }
            //};
            //modelBuilder.Entity<Branch>().HasData(branches);

            //List<Classification> classifications = new List<Classification>();


            //var classId = 1;
            //foreach (var item in Enum.GetValues(typeof(Air)))
            //{
            //    var newClass = new Classification()
            //    {
            //        ClassificationId = classId,
            //        FullName = item.ToString(),
            //        BranchId = 2,
            //    };
            //    classId++;
            //    classifications.Add(newClass);
            //}
            //foreach (var item in Enum.GetValues(typeof(Land)))
            //{
            //    var newClass = new Classification()
            //    {
            //        ClassificationId = classId,
            //        FullName = item.ToString(),
            //        BranchId = 3,
            //    };
            //    classId++;
            //    classifications.Add(newClass);
            //}
            //foreach (var item in Enum.GetValues(typeof(Naval)))
            //{
            //    var newClass = new Classification()
            //    {
            //        ClassificationId = classId,
            //        FullName = item.ToString(),
            //        BranchId = 1,
            //    };
            //    classId++;
            //    classifications.Add(newClass);
            //}

            //modelBuilder.Entity<Classification>().HasData(classifications);

            //var land = Classifications.Where(c => c.BranchId == 3);
            //Branches.Find(3).Classifications.AddRange(land);
            //var air = Classifications.Where(c => c.BranchId == 2);
            //Branches.Find(2).Classifications.AddRange(air);
            //var naval = Classifications.Where(c => c.BranchId == 1);
            //Branches.Find(1).Classifications.AddRange(naval);

            base.OnModelCreating(modelBuilder);

        }

    }
}
