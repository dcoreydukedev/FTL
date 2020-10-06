﻿// <auto-generated />
using System;
using FortyThreeLime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FortyThreeLime.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201005223907_AddAppAuth")]
    partial class AddAppAuth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("FortyThreeLime.Models.Entities.AppAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginExpires")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginToken")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LoginTokenActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LogoutTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId1");

                    b.ToTable("AppAuth");
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("AppToken")
                        .HasColumnType("TEXT")
                        .HasMaxLength(512);

                    b.Property<int>("AppType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AppName");

                    b.HasIndex("AppToken");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppName = "FortyThreeLime.Web",
                            AppToken = "a4Y0281F95Gth40GJe9q09swk3XK",
                            AppType = 1,
                            Description = "Web Portal for Solution"
                        },
                        new
                        {
                            Id = 2,
                            AppName = "FortyThreeLime.API",
                            AppToken = "GeC34y742m6oC9wBcs634hM3V8R1",
                            AppType = 0,
                            Description = "Web API for Solution"
                        },
                        new
                        {
                            Id = 3,
                            AppName = "FortyThreeLime.Mobile.Android",
                            AppToken = "C4LX502J3b6ioqJ7Es86ulm5X3p9",
                            AppType = 2,
                            Description = "Android Application for Solution"
                        });
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.ButtonCommand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Command")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<int>("CommandId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ButtonCommands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Command = "Start Day",
                            CommandId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Command = "End Day",
                            CommandId = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Command = "Start Lunch",
                            CommandId = 3
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Command = "End Lunch",
                            CommandId = 4
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Command = "Start Break",
                            CommandId = 5
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Command = "End Break",
                            CommandId = 6
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Command = "Off Duty",
                            CommandId = 9
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Command = "Select Loader",
                            CommandId = 10
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Command = "Load Scalper",
                            CommandId = 11,
                            ParentId = 10
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Command = "Load Truck",
                            CommandId = 12,
                            ParentId = 10
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Command = "Move Material",
                            CommandId = 13,
                            ParentId = 10
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Command = "Fork Work",
                            CommandId = 14,
                            ParentId = 10
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Command = "Equipment Issue",
                            CommandId = 15,
                            ParentId = 10
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Command = "Select Water Truck",
                            CommandId = 20
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Command = "Fill Truck",
                            CommandId = 21,
                            ParentId = 20
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 3,
                            Command = "Water Road",
                            CommandId = 22,
                            ParentId = 20
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 3,
                            Command = "Equipment Issue",
                            CommandId = 23,
                            ParentId = 20
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 2,
                            Command = "Select Tractor",
                            CommandId = 30
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 3,
                            Command = "Road Work",
                            CommandId = 31,
                            ParentId = 30
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 3,
                            Command = "Clean Up",
                            CommandId = 32,
                            ParentId = 30
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 3,
                            Command = "Fork Work",
                            CommandId = 33,
                            ParentId = 30
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 3,
                            Command = "Equipment Issue",
                            CommandId = 34,
                            ParentId = 30
                        });
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.ButtonCommandCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1500);

                    b.HasKey("Id");

                    b.ToTable("ButtonCommandCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "WorkDay",
                            Description = "Buttons pertaining to the work day as a whole."
                        },
                        new
                        {
                            Id = 2,
                            Category = "MainTask",
                            Description = "Buttons non the main screen pertaining to the main tasks performed during the workday."
                        },
                        new
                        {
                            Id = 3,
                            Category = "SubTask",
                            Description = "Buttons accessed by clicking a main function button. Pertains to the main task"
                        });
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.CommandLogRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<long>("Timestamp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4);

                    b.Property<int?>("UserId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CommandId");

                    b.HasIndex("UserId1");

                    b.ToTable("CommandLog");
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "ReportUser"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsOnline")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4);

                    b.Property<string>("Username")
                        .HasColumnType("TEXT")
                        .HasMaxLength(56);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 1,
                            UserId = "0001",
                            Username = "Administrator 1"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 1,
                            UserId = "1001",
                            Username = "Administrator 2"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 2,
                            UserId = "0002",
                            Username = "Report User 1"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 2,
                            UserId = "1002",
                            Username = "Report User 2"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "0003",
                            Username = "User 1"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "1003",
                            Username = "User 2"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "0004",
                            Username = "User 3"
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "1004",
                            Username = "User 4"
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "2000",
                            Username = "Operator 1"
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "2001",
                            Username = "Operator 2"
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "2002",
                            Username = "Operator 3"
                        },
                        new
                        {
                            Id = 12,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "2003",
                            Username = "Operator 4"
                        },
                        new
                        {
                            Id = 13,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "5550",
                            Username = "Subject 1"
                        },
                        new
                        {
                            Id = 14,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "5551",
                            Username = "Subject 2"
                        },
                        new
                        {
                            Id = 15,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "5552",
                            Username = "Subject 3"
                        },
                        new
                        {
                            Id = 16,
                            IsActive = true,
                            IsOnline = false,
                            RoleId = 3,
                            UserId = "5553",
                            Username = "Subject 4"
                        });
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.AppAuth", b =>
                {
                    b.HasOne("FortyThreeLime.Models.Entities.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortyThreeLime.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortyThreeLime.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.ButtonCommand", b =>
                {
                    b.HasOne("FortyThreeLime.Models.Entities.ButtonCommandCategory", "Category")
                        .WithMany("ButtonCommands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FortyThreeLime.Models.Entities.CommandLogRecord", b =>
                {
                    b.HasOne("FortyThreeLime.Models.Entities.ButtonCommand", "Command")
                        .WithMany("CommandLogs")
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FortyThreeLime.Models.Entities.User", "User")
                        .WithMany("CommandLogs")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
