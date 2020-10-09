/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FortyThreeLime.Repository;
using FortyThreeLime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace FortyThreeLime.API
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

            // Add Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDistributedMemoryCache();

            services.AddMvc(opts => {
                opts.EnableEndpointRouting = false;
            });

            services.AddCors();

            services.AddEntityFrameworkSqlite();

            // Session State 
            services.AddSession(opts => { opts.Cookie.HttpOnly = true; opts.Cookie.IsEssential = true; opts.IdleTimeout = TimeSpan.FromHours(12); });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Changed to ~WithViews For MVC Homepage
            services.AddControllersWithViews(options => {
                options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                options.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            })
                .AddNewtonsoftJson(options => { });            

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if(env.IsProduction())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMvc();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
