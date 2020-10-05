/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FortyThreeLime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using FortyThreeLime.Repository;
using FortyThreeLime.Web.Services;
using FortyThreeLime.Web.Services.Data;

namespace FortyThreeLime.Web
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
            // Add DB Context
            services.AddDbContext<ApplicationDbContext>(
                    opt => opt.EnableDetailedErrors().UseSqlite(@"Data Source=C:\FortyThreeLime\DB\43LimeMobileApp.db", options =>
                    {
                        options.MigrationsAssembly(System.Reflection.Assembly.GetExecutingAssembly().FullName);
                    })
                );

            services.AddDistributedMemoryCache();

            services.AddMvcCore();

            services.AddCors();

            services.AddEntityFrameworkSqlite();

            services.AddSession(opts => { opts.Cookie.HttpOnly = true; opts.Cookie.IsEssential = true; opts.IdleTimeout = TimeSpan.FromSeconds(1800); });

            services.AddControllersWithViews();

            services.AddWebEncoders();

            // Add Repository
            services.AddScoped(typeof(IRepository<>), typeof(ApplicationRepository<>));
        
            // Add Custom Data Services
            services.AddTransient<IDataService, AddressService>();
            services.AddTransient<IDataService, LatLngService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseRequestLocalization();

            app.UseCors();

            app.UseAuthorization();

            app.UseSession();

            app.UseResponseCaching();

            //  MapControllers is called inside UseEndpoints to map attribute routed controllers.
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
