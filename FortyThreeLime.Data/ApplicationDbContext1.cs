/*************************************************************************
 * Author:  DCoreyDuke
 * Version: 1.0.0.0
 * Description: SQLite DB Context for Solution
 ************************************************************************/
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FortyThreeLime.Models.Entities;

namespace FortyThreeLime.Data
{
    public partial class ApplicationDbContext : DbContext
    {

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationDbContext() : base()
        {

        }

        /// <summary>
        /// Constructor Accepting Options from Startup
        /// </summary>
        /// <param name="opts"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {

        }

        /// <summary>
        /// Create Method
        /// </summary>
        /// <returns>new ApplicationDbContext()</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Create Method
        /// </summary>
        /// <returns>new ApplicationDbContext(opts)</returns>
        public static ApplicationDbContext Create(DbContextOptions<ApplicationDbContext> opts)
        {
            return new ApplicationDbContext(opts);
        }

        #endregion

        #region DB Sets

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ButtonCommand> ButtonCommands { get; set; }
        public DbSet<ButtonCommandCategory> ButtonCommandCategories { get; set; }
        public DbSet<CommandLogRecord> CommandLog { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<AppAuth> AppAuth { get; set; }

        #endregion        

        /// <summary>
        /// Supply Connection String Here
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Moved to Webb App strtup.cs
            optionsBuilder.UseSqlite(@"Data Source=C:\FortyThreeLime\DB\43LimeMobileApp.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

    }
}
