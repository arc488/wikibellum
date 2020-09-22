using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using wikibellum.Data;
using wikibellum.Data.Data;
using wikibellum.Data.Data.IRepositiories;

namespace wikibellum.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<WikiContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<WikiContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, WikiContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();


            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventParticipantRepository, EventParticipantRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<INationRepository, NationRepository>();
            services.AddScoped<IAllianceRepository, AllianceRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("Open");

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");

            });
        }
    }
}
