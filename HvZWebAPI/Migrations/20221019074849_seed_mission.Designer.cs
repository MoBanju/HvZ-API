﻿// <auto-generated />
using System;
using HvZWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HvZWebAPI.Migrations
{
    [DbContext(typeof(HvZDbContext))]
    [Migration("20221019074849_seed_mission")]
    partial class seed_mission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HvZWebAPI.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ChatTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHumanGlobal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsZombieGlobal")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChatTime = new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1161),
                            GameId = 3,
                            IsHumanGlobal = false,
                            IsZombieGlobal = true,
                            Message = "Got him!",
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 2,
                            ChatTime = new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1165),
                            GameId = 2,
                            IsHumanGlobal = false,
                            IsZombieGlobal = false,
                            Message = "Run away!",
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 3,
                            ChatTime = new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1166),
                            GameId = 1,
                            IsHumanGlobal = true,
                            IsZombieGlobal = false,
                            Message = "Like... Hello",
                            PlayerId = 7
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Ne_lat")
                        .HasColumnType("float");

                    b.Property<double>("Ne_lng")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<double>("Sw_lat")
                        .HasColumnType("float");

                    b.Property<double>("Sw_lng")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hosted by George of the Jungle.",
                            EndTime = new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jungle",
                            Ne_lat = 60.395527999999999,
                            Ne_lng = 5.320989,
                            StartTime = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 0,
                            Sw_lat = 60.395122999999998,
                            Sw_lng = 5.3146870000000002
                        },
                        new
                        {
                            Id = 2,
                            Description = "Match happens in Finland.",
                            EndTime = new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Island",
                            Ne_lat = 58.984830000000002,
                            Ne_lng = 5.619021,
                            StartTime = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 1,
                            Sw_lat = 58.983857,
                            Sw_lng = 5.613486
                        },
                        new
                        {
                            Id = 3,
                            Description = "Sharks, Bombs and Boats.",
                            EndTime = new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ocean",
                            Ne_lat = 58.895001999999998,
                            Ne_lng = 5.6449809999999996,
                            StartTime = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 1,
                            Sw_lat = 58.870288000000002,
                            Sw_lng = 5.6021359999999998
                        },
                        new
                        {
                            Id = 4,
                            Description = "Armstrong in the building.",
                            EndTime = new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Space",
                            Ne_lat = 58.964326999999997,
                            Ne_lng = 5.8464679999999998,
                            StartTime = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 2,
                            Sw_lat = 58.940604999999998,
                            Sw_lng = 5.8035119999999996
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.Kill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeDeath")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Kills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "CAMPER!!",
                            GameId = 2,
                            Latitude = 58.983899999999998,
                            Longitude = 5.6150000000000002,
                            TimeDeath = new DateTime(2022, 10, 13, 13, 37, 59, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "GET HIM!",
                            GameId = 2,
                            Latitude = 58.984172999999998,
                            Longitude = 5.6151669999999996,
                            TimeDeath = new DateTime(2022, 10, 14, 13, 37, 59, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            GameId = 3,
                            Latitude = 58.885641999999997,
                            Longitude = 5.6335850000000001,
                            TimeDeath = new DateTime(2022, 10, 13, 13, 37, 59, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            GameId = 3,
                            Latitude = 58.893352999999998,
                            Longitude = 5.6372780000000002,
                            TimeDeath = new DateTime(2022, 10, 14, 13, 37, 59, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("End_time")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("Is_human_visible")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_zombie_visible")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Start_time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Missions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Touch your head!",
                            End_time = new DateTime(2022, 10, 19, 9, 48, 48, 839, DateTimeKind.Utc).AddTicks(1244),
                            GameId = 3,
                            Is_human_visible = true,
                            Is_zombie_visible = false,
                            Latitude = 58.880000000000003,
                            Longitude = 5.6100000000000003,
                            Name = "Head here",
                            Start_time = new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1243)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Touch your toes!",
                            End_time = new DateTime(2022, 10, 19, 8, 48, 48, 839, DateTimeKind.Utc).AddTicks(1253),
                            GameId = 2,
                            Is_human_visible = true,
                            Is_zombie_visible = false,
                            Latitude = 58.983899999999998,
                            Longitude = 5.6139999999999999,
                            Name = "Take a trip",
                            Start_time = new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1253)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Jump up on the table and do a zombie dance!",
                            End_time = new DateTime(2022, 10, 19, 11, 48, 48, 839, DateTimeKind.Utc).AddTicks(1256),
                            GameId = 2,
                            Is_human_visible = false,
                            Is_zombie_visible = true,
                            Latitude = 58.983980000000003,
                            Longitude = 5.617,
                            Name = "JigglyBrains",
                            Start_time = new DateTime(2022, 10, 19, 7, 48, 48, 839, DateTimeKind.Utc).AddTicks(1256)
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BiteCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHuman")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPatientZero")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BiteCode")
                        .IsUnique();

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            BiteCode = "Five",
                            GameId = 1,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            BiteCode = "Seven",
                            GameId = 1,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            BiteCode = "Six",
                            GameId = 1,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 3
                        },
                        new
                        {
                            Id = 1,
                            BiteCode = "Street",
                            GameId = 2,
                            IsHuman = false,
                            IsPatientZero = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            BiteCode = "Helloma",
                            GameId = 2,
                            IsHuman = false,
                            IsPatientZero = true,
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            BiteCode = "Eight",
                            GameId = 3,
                            IsHuman = false,
                            IsPatientZero = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            BiteCode = "Nine",
                            GameId = 3,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            BiteCode = "BooHoo",
                            GameId = 3,
                            IsHuman = false,
                            IsPatientZero = false,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            BiteCode = "Hello",
                            GameId = 3,
                            IsHuman = false,
                            IsPatientZero = true,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.PlayerKill", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("KillId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVictim")
                        .HasColumnType("bit");

                    b.HasKey("PlayerId", "KillId", "IsVictim");

                    b.HasIndex("KillId");

                    b.ToTable("PlayerKills");

                    b.HasData(
                        new
                        {
                            PlayerId = 4,
                            KillId = 1,
                            IsVictim = true
                        },
                        new
                        {
                            PlayerId = 1,
                            KillId = 1,
                            IsVictim = false
                        },
                        new
                        {
                            PlayerId = 2,
                            KillId = 2,
                            IsVictim = true
                        },
                        new
                        {
                            PlayerId = 3,
                            KillId = 2,
                            IsVictim = false
                        },
                        new
                        {
                            PlayerId = 8,
                            KillId = 3,
                            IsVictim = true
                        },
                        new
                        {
                            PlayerId = 3,
                            KillId = 3,
                            IsVictim = false
                        },
                        new
                        {
                            PlayerId = 2,
                            KillId = 4,
                            IsVictim = true
                        },
                        new
                        {
                            PlayerId = 8,
                            KillId = 4,
                            IsVictim = false
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KeyCloakId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("KeyCloakId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "mordi",
                            KeyCloakId = "f416c45a-2945-4047-b609-06de42279237",
                            LastName = "007"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Øyvind",
                            KeyCloakId = "2e951202-167e-40fd-8fb1-91d2416d0d10",
                            LastName = "Sande Reitan"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Funny",
                            KeyCloakId = "816cf1b0-c9e5-47b1-92f0-5927695b238a",
                            LastName = "Man"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Bertelsen",
                            KeyCloakId = "d2cb4a5b-3bb1-4a36-b3ae-a370c26e9646",
                            LastName = "Eivind"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Kaffi",
                            KeyCloakId = "fa31d802-1e3c-4909-b9e9-210978fd9688",
                            LastName = "Elsker"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Vann",
                            KeyCloakId = "cd501590-5292-41cd-a170-7fea0b879bb0",
                            LastName = "Elsker"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Cola",
                            KeyCloakId = "6cbfe3cb-9e81-438a-a56c-625624efc2a4",
                            LastName = "Elske"
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.Chat", b =>
                {
                    b.HasOne("HvZWebAPI.Models.Game", "Game")
                        .WithMany("Chats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HvZWebAPI.Models.Player", "Player")
                        .WithMany("Chats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HvZWebAPI.Models.Kill", b =>
                {
                    b.HasOne("HvZWebAPI.Models.Game", "Game")
                        .WithMany("Kills")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("HvZWebAPI.Models.Mission", b =>
                {
                    b.HasOne("HvZWebAPI.Models.Game", "Game")
                        .WithMany("Missions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("HvZWebAPI.Models.Player", b =>
                {
                    b.HasOne("HvZWebAPI.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HvZWebAPI.Models.User", "User")
                        .WithMany("Players")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HvZWebAPI.Models.PlayerKill", b =>
                {
                    b.HasOne("HvZWebAPI.Models.Kill", "Kill")
                        .WithMany("PlayerKills")
                        .HasForeignKey("KillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HvZWebAPI.Models.Player", "Player")
                        .WithMany("PlayerKills")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kill");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HvZWebAPI.Models.Game", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("Kills");

                    b.Navigation("Missions");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("HvZWebAPI.Models.Kill", b =>
                {
                    b.Navigation("PlayerKills");
                });

            modelBuilder.Entity("HvZWebAPI.Models.Player", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("PlayerKills");
                });

            modelBuilder.Entity("HvZWebAPI.Models.User", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
