using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using wikibellum.Data;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Data.Data;
using wikibellum.Entities;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace wikibellum.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WikiContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<WikiContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, WikiContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });


            services.AddControllersWithViews(config =>
                config.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build())));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventParticipantRepository, EventParticipantRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<INationRepository, NationRepository>();
            services.AddScoped<IAllianceRepository, AllianceRepository>();
            services.AddScoped<IEventAnonymousRepository, EventAnonymousRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();



            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();
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
