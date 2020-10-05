using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FortyThreeLime.Data;
using FortyThreeLime.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;

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
                    opt => opt.EnableDetailedErrors().UseSqlite(@"Data Source=C:\FortyTrheeLime\DB\43LimeMobileApp.db", options =>
                    {
                        options.MigrationsAssembly(System.Reflection.Assembly.GetExecutingAssembly().FullName);
                    })
                );

            services.AddDistributedMemoryCache();

            services.AddMvcCore();

            services.AddCors();

            services.AddEntityFrameworkSqlite();

            services.AddSession(opts => { opts.Cookie.HttpOnly = true; opts.Cookie.IsEssential = true; opts.IdleTimeout = TimeSpan.FromSeconds(1800); });

            services.AddControllersWithViews(options => {
                    options.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();
                    options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                })
                .AddNewtonsoftJson(options =>{});

            services.AddWebEncoders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
