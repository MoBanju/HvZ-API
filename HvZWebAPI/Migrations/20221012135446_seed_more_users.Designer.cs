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
    [Migration("20221012135446_seed_more_users")]
    partial class seed_more_users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
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
                        .HasColumnType("nvarchar(max)");

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
                            ChatTime = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2339),
                            GameId = 2,
                            IsHumanGlobal = false,
                            IsZombieGlobal = true,
                            Message = "Got him!",
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 2,
                            ChatTime = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2378),
                            GameId = 2,
                            IsHumanGlobal = true,
                            IsZombieGlobal = false,
                            Message = "Run away!",
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 3,
                            ChatTime = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2379),
                            GameId = 2,
                            IsHumanGlobal = false,
                            IsZombieGlobal = false,
                            Message = "Like... Hello",
                            PlayerId = 3
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
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hosted by George of the Jungle.",
                            Name = "Jungle",
                            State = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Match happens in Finland.",
                            Name = "Island",
                            State = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Sharks, Bombs and Boats.",
                            Name = "Ocean",
                            State = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Armstrong in the building.",
                            Name = "Space",
                            State = 2
                        });
                });

            modelBuilder.Entity("HvZWebAPI.Models.Kill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeDeath")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Kills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 2,
                            TimeDeath = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2314)
                        },
                        new
                        {
                            Id = 2,
                            GameId = 2,
                            TimeDeath = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2318)
                        },
                        new
                        {
                            Id = 3,
                            GameId = 2,
                            TimeDeath = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2319)
                        },
                        new
                        {
                            Id = 4,
                            GameId = 3,
                            TimeDeath = new DateTime(2022, 10, 12, 13, 54, 45, 813, DateTimeKind.Utc).AddTicks(2320)
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
                            Id = 1,
                            BiteCode = "Street",
                            GameId = 2,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BiteCode = "BooHoo",
                            GameId = 3,
                            IsHuman = false,
                            IsPatientZero = true,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            BiteCode = "Hello",
                            GameId = 3,
                            IsHuman = false,
                            IsPatientZero = false,
                            UserId = 4
                        },
                        new
                        {
                            Id = 4,
                            BiteCode = "Helloma",
                            GameId = 2,
                            IsHuman = true,
                            IsPatientZero = false,
                            UserId = 2
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
                            PlayerId = 1,
                            KillId = 1,
                            IsVictim = false
                        },
                        new
                        {
                            PlayerId = 4,
                            KillId = 1,
                            IsVictim = true
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
                        .HasColumnType("nvarchar(450)");

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