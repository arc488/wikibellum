using Microsoft.Extensions.DependencyInjection;
using System;
using wikibellum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using wikibellum.Entities.Data;

namespace armaschema.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=wikiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var services = new ServiceCollection();

            services.AddTransient<IEventRepository, EventRepository>();
            services.AddDbContext<WikiContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<WikiContext>();

            var serviceProvider = services.BuildServiceProvider();

            var adder = new Adder(serviceProvider.GetService<IEventRepository>());
            var dtos = adder.ParseJson();
            var events = adder.DtoToEvent(dtos);

        }
    }
}
