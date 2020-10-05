/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FortyThreeLime.API.Services;
using FortyThreeLime.Repository;
using FortyThreeLime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;

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

            services.AddDistributedMemoryCache();

            services.AddCors();

            services.AddEntityFrameworkSqlite();

            services.AddSession(opts => { opts.Cookie.HttpOnly = true; opts.Cookie.IsEssential = true; opts.IdleTimeout = TimeSpan.FromSeconds(1800); });

            services.AddControllers(options => {
                options.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            })
                .AddNewtonsoftJson(options => { });

            // Add Repository
            services.AddScoped(typeof(IRepository<>), typeof(ApplicationRepository<>));

            // Add Custom API Services
            services.AddTransient<IAPIService, ButtonCommandService>();
            services.AddTransient<IAPIService, CommandLogService>();
            services.AddTransient<IAPIService, RoleService>();
            services.AddTransient<IAPIService, UserService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
