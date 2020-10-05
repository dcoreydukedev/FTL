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
    public class ApplicationDbContext : DbContext
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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ButtonCommand> ButtonCommands { get; set; }
        public virtual DbSet<ButtonCommandCategory> ButtonCommandCategories { get; set; }
        public virtual DbSet<CommandLogRecord> CommandLog { get; set; }
        public virtual DbSet<Application> Applications { get; set; }

        #endregion

        /// <summary>
        /// OnModelCreating
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /* -- Configure Tables -- */
            #region Configure Tables

            // Users
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(u => {
                u.HasKey(uu => uu.Id);
                u.HasIndex(uu => uu.UserId).IsUnique();
                u.Property(uu => uu.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
                u.Property(uu => uu.IsActive).HasColumnType("INTEGER");
                u.Property(uu => uu.IsOnline).HasColumnType("INTEGER");
                u.Property(uu => uu.RoleId).HasColumnType("INTEGER");
                u.Property(uu => uu.UserId).HasColumnType("TEXT").HasMaxLength(4);
                u.Property(uu => uu.Username).HasColumnType("TEXT").HasMaxLength(56);
            });

            // Roles
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>(r => {
                r.HasKey(rr => rr.Id);
                r.HasIndex(rr => rr.RoleName).IsUnique();
                r.Property(rr => rr.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
                r.Property(rr => rr.RoleName).HasColumnType("TEXT").HasMaxLength(128);
            });

            // ButtonCommands
            modelBuilder.Entity<ButtonCommand>().ToTable("ButtonCommands");
            modelBuilder.Entity<ButtonCommand>(bc => {
                bc.HasKey(bcc => bcc.Id);
                bc.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                bc.Property<int>("CategoryId").HasColumnType("INTEGER");
                bc.Property<string>("Command").HasColumnType("TEXT").HasMaxLength(256);
                bc.Property<int>("CommandId").HasColumnType("INTEGER");
                bc.Property<int?>("ParentId").HasColumnType("INTEGER");
                bc.HasIndex("CategoryId");
                bc.HasOne("FortyThreeLime.Models.Entities.ButtonCommandCategory", "Category")
                   .WithMany("ButtonCommands")
                   .HasForeignKey("CategoryId")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
            });

            // ButtonCommandCategories
            modelBuilder.Entity<ButtonCommandCategory>().ToTable("ButtonCommandCategories");
            modelBuilder.Entity<ButtonCommandCategory>(bcc => {
                bcc.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                bcc.Property<string>("Category").HasColumnType("TEXT").HasMaxLength(256);
                bcc.Property<string>("Description").HasColumnType("TEXT").HasMaxLength(1500);
                bcc.HasKey("Id");
            });

            // CommandLog
            modelBuilder.Entity<CommandLogRecord>().ToTable("CommandLog");
            modelBuilder.Entity<CommandLogRecord>(clr => {
                clr.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                clr.Property<int>("CommandId").HasColumnType("INTEGER");
                clr.Property<string>("Latitude").HasColumnType("TEXT");
                clr.Property<string>("Longitude").HasColumnType("TEXT");
                clr.Property<long>("Timestamp").HasColumnType("INTEGER");
                clr.Property<string>("UserId").HasColumnType("TEXT").HasMaxLength(4);
                clr.Property<int?>("UserId1").HasColumnType("INTEGER");
                clr.HasKey("Id");
                clr.HasIndex("CommandId");
                clr.HasIndex("UserId1");
                clr.HasOne("FortyThreeLime.Models.Entities.ButtonCommand", "Command")
                   .WithMany("CommandLogs")
                   .HasForeignKey("CommandId")
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

                clr.HasOne("FortyThreeLime.Models.Entities.User", "User")
                    .WithMany("CommandLogs")
                    .HasForeignKey("UserId1");
            });

            // Applications
            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<Application>().Property(a => a.AppType).HasConversion<int>();
            modelBuilder.Entity<Application>(app => {
                app.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                app.Property<string>("AppName").HasColumnType("TEXT");
                app.Property<int>("AppType").HasColumnType("INTEGER");
                app.Property<string>("Description").HasColumnType("TEXT");
                app.Property<string>("AppToken").HasColumnType("TEXT");
                app.HasKey("Id");
                app.HasIndex("AppName");
                app.HasIndex("AppToken");                
            });
            

            #endregion
            /* -- End Configure Tables -- */

            /* -- Seed Data -- */
            #region Seed Data

            // Roles
            #region Roles
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, RoleName = "Administrator" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = "ReportUser" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, RoleName = "User" });
            #endregion

            // Test Users
            #region Test Users
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserId = "0001", Username = "Administrator 1", RoleId = 1, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, UserId = "1001", Username = "Administrator 2", RoleId = 1, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 3, UserId = "0002", Username = "Report User 1", RoleId = 2, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 4, UserId = "1002", Username = "Report User 2", RoleId = 2, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 5, UserId = "0003", Username = "User 1", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 6, UserId = "1003", Username = "User 2", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 7, UserId = "0004", Username = "User 3", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 8, UserId = "1004", Username = "User 4", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 9, UserId = "2000", Username = "Operator 1", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 10, UserId = "2001", Username = "Operator 2", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 11, UserId = "2002", Username = "Operator 3", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 12, UserId = "2003", Username = "Operator 4", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 13, UserId = "5550", Username = "Subject 1", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 14, UserId = "5551", Username = "Subject 2", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 15, UserId = "5552", Username = "Subject 3", RoleId = 3, IsActive = true, IsOnline = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 16, UserId = "5553", Username = "Subject 4", RoleId = 3, IsActive = true, IsOnline = false });
            #endregion

            // Button Command Categories
            #region Button Command Categories
            modelBuilder.Entity<ButtonCommandCategory>().HasData(
                new ButtonCommandCategory{ Id = 1, Category = "WorkDay", Description = "Buttons pertaining to the work day as a whole." });
            modelBuilder.Entity<ButtonCommandCategory>().HasData(
                new ButtonCommandCategory { Id = 2, Category = "MainTask", Description = "Buttons non the main screen pertaining to the main tasks performed during the workday." });
            modelBuilder.Entity<ButtonCommandCategory>().HasData(
                new ButtonCommandCategory { Id = 3, Category = "SubTask", Description = "Buttons accessed by clicking a main function button. Pertains to the main task" });
            #endregion

            // Button Commands
            #region Button Commands
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 1,CommandId = 1, Command = "Start Day", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 2,CommandId = 2, Command = "End Day", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 3,CommandId = 3, Command = "Start Lunch", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 4,CommandId = 4, Command = "End Lunch", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 5,CommandId = 5, Command = "Start Break", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 6,CommandId = 6, Command = "End Break", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 7,CommandId = 9, Command = "Off Duty", ParentId = null, CategoryId = 1 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 8,CommandId = 10, Command = "Select Loader", ParentId = null, CategoryId = 2 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 9,CommandId = 11, Command = "Load Scalper", ParentId = 10, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 10,CommandId = 12, Command = "Load Truck", ParentId = 10, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 11,CommandId = 13, Command = "Move Material", ParentId = 10, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 12,CommandId = 14, Command = "Fork Work", ParentId = 10, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 13,CommandId = 15, Command = "Equipment Issue", ParentId = 10, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 14,CommandId = 20, Command = "Select Water Truck", ParentId = null, CategoryId = 2 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 15,CommandId = 21, Command = "Fill Truck", ParentId = 20, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 16,CommandId = 22, Command = "Water Road", ParentId = 20, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 17,CommandId = 23, Command = "Equipment Issue", ParentId = 20, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 18,CommandId = 30, Command = "Select Tractor", ParentId = null, CategoryId = 2 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 19,CommandId = 31, Command = "Road Work", ParentId = 30, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 20,CommandId = 32, Command = "Clean Up", ParentId = 30, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 21,CommandId = 33, Command = "Fork Work", ParentId = 30, CategoryId = 3 });
            modelBuilder.Entity<ButtonCommand>().HasData(new ButtonCommand { Id = 22, CommandId = 34, Command = "Equipment Issue", ParentId = 30, CategoryId = 3 });
            #endregion

            // Applications
            #region Applications

            modelBuilder.Entity<Application>().HasData(new Application {
                Id = 1, 
                AppName = "FortyThreeLime.Web", 
                AppType = 1, 
                Description = "Web Portal for Solution", 
                AppToken = "a4Y0281F95Gth40GJe9q09swk3XK"
            });

            modelBuilder.Entity<Application>().HasData(new Application
            {
                Id = 2,
                AppName = "FortyThreeLime.API",
                AppType = 0,
                Description = "Web API for Solution",
                AppToken = "GeC34y742m6oC9wBcs634hM3V8R1"
            });

            modelBuilder.Entity<Application>().HasData(new Application
            {
                Id = 3,
                AppName = "FortyThreeLime.Mobile.Android",
                AppType = 2,
                Description = "Android Application for Solution",
                AppToken = "C4LX502J3b6ioqJ7Es86ulm5X3p9"
            });

            #endregion

            #endregion
            /* -- End Seed Data -- */
            base.OnModelCreating(modelBuilder);
        }

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
