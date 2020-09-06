﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wikibellum.Data;

namespace wikibellum.Data.Migrations
{
    [DbContext(typeof(WikiContext))]
    [Migration("20200906083417_addedConditionIdPropToAsset")]
    partial class addedConditionIdPropToAsset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("wikibellum.Entities.BookRecommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookRecommendation");
                });

            modelBuilder.Entity("wikibellum.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("ReccomendationId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ReccomendationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("wikibellum.Entities.EventParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("wikibellum.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("wikibellum.Entities.Models.Units.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("AssetType")
                        .HasColumnType("int");

                    b.Property<string>("ClassificationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClassificationId1")
                        .HasColumnType("int");

                    b.Property<string>("ConditionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EventParticipantId")
                        .HasColumnType("int");

                    b.Property<int?>("EventParticipantId1")
                        .HasColumnType("int");

                    b.HasKey("AssetId");

                    b.HasIndex("ClassificationId1");

                    b.HasIndex("ConditionId");

                    b.HasIndex("EventParticipantId");

                    b.HasIndex("EventParticipantId1");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("wikibellum.Entities.Models.Units.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            Name = "Naval"
                        },
                        new
                        {
                            BranchId = 2,
                            Name = "Air"
                        },
                        new
                        {
                            BranchId = 3,
                            Name = "Land"
                        });
                });

            modelBuilder.Entity("wikibellum.Entities.Models.Units.Classification", b =>
                {
                    b.Property<int>("ClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbbrName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassificationId");

                    b.HasIndex("BranchId");

                    b.ToTable("Classifications");

                    b.HasData(
                        new
                        {
                            ClassificationId = 1,
                            BranchId = 2,
                            FullName = "Fighter"
                        },
                        new
                        {
                            ClassificationId = 2,
                            BranchId = 2,
                            FullName = "Medium_bomber"
                        },
                        new
                        {
                            ClassificationId = 3,
                            BranchId = 2,
                            FullName = "Heavy_bomber"
                        },
                        new
                        {
                            ClassificationId = 4,
                            BranchId = 2,
                            FullName = "Other"
                        },
                        new
                        {
                            ClassificationId = 5,
                            BranchId = 3,
                            FullName = "Infantry"
                        },
                        new
                        {
                            ClassificationId = 6,
                            BranchId = 3,
                            FullName = "Tank"
                        },
                        new
                        {
                            ClassificationId = 7,
                            BranchId = 3,
                            FullName = "Tankette"
                        },
                        new
                        {
                            ClassificationId = 8,
                            BranchId = 3,
                            FullName = "Light_tank"
                        },
                        new
                        {
                            ClassificationId = 9,
                            BranchId = 3,
                            FullName = "Medium_tank"
                        },
                        new
                        {
                            ClassificationId = 10,
                            BranchId = 3,
                            FullName = "Heavy_tank"
                        },
                        new
                        {
                            ClassificationId = 11,
                            BranchId = 3,
                            FullName = "Tank_destroyer"
                        },
                        new
                        {
                            ClassificationId = 12,
                            BranchId = 3,
                            FullName = "Self_propelled_artillery"
                        },
                        new
                        {
                            ClassificationId = 13,
                            BranchId = 3,
                            FullName = "Self_propelled_anti_aircraft_gun"
                        },
                        new
                        {
                            ClassificationId = 14,
                            BranchId = 3,
                            FullName = "Armoured_personnel_carrier"
                        },
                        new
                        {
                            ClassificationId = 15,
                            BranchId = 3,
                            FullName = "Armoured_car"
                        },
                        new
                        {
                            ClassificationId = 16,
                            BranchId = 3,
                            FullName = "Artillery_tractor"
                        },
                        new
                        {
                            ClassificationId = 17,
                            BranchId = 3,
                            FullName = "Amphibious"
                        },
                        new
                        {
                            ClassificationId = 18,
                            BranchId = 3,
                            FullName = "Utility_vehicle"
                        },
                        new
                        {
                            ClassificationId = 19,
                            BranchId = 3,
                            FullName = "Rocket_artillery"
                        },
                        new
                        {
                            ClassificationId = 20,
                            BranchId = 3,
                            FullName = "Other"
                        },
                        new
                        {
                            ClassificationId = 21,
                            BranchId = 1,
                            FullName = "Sailors"
                        },
                        new
                        {
                            ClassificationId = 22,
                            BranchId = 1,
                            FullName = "Aircraft_carrier"
                        },
                        new
                        {
                            ClassificationId = 23,
                            BranchId = 1,
                            FullName = "Battleship"
                        },
                        new
                        {
                            ClassificationId = 24,
                            BranchId = 1,
                            FullName = "Battlecruiser"
                        },
                        new
                        {
                            ClassificationId = 25,
                            BranchId = 1,
                            FullName = "Coastal_defence_ship"
                        },
                        new
                        {
                            ClassificationId = 26,
                            BranchId = 1,
                            FullName = "Monitor"
                        },
                        new
                        {
                            ClassificationId = 27,
                            BranchId = 1,
                            FullName = "Destroyer"
                        },
                        new
                        {
                            ClassificationId = 28,
                            BranchId = 1,
                            FullName = "Frigate"
                        },
                        new
                        {
                            ClassificationId = 29,
                            BranchId = 1,
                            FullName = "Corvette"
                        },
                        new
                        {
                            ClassificationId = 30,
                            BranchId = 1,
                            FullName = "Cruiser"
                        },
                        new
                        {
                            ClassificationId = 31,
                            BranchId = 1,
                            FullName = "Heavy_cruiser"
                        },
                        new
                        {
                            ClassificationId = 32,
                            BranchId = 1,
                            FullName = "Light_cruiser"
                        },
                        new
                        {
                            ClassificationId = 33,
                            BranchId = 1,
                            FullName = "Submarine"
                        },
                        new
                        {
                            ClassificationId = 34,
                            BranchId = 1,
                            FullName = "Mine_layer"
                        },
                        new
                        {
                            ClassificationId = 35,
                            BranchId = 1,
                            FullName = "Patrol_boat"
                        },
                        new
                        {
                            ClassificationId = 36,
                            BranchId = 1,
                            FullName = "Torpedo_boat"
                        },
                        new
                        {
                            ClassificationId = 37,
                            BranchId = 1,
                            FullName = "Landing_craft"
                        });
                });

            modelBuilder.Entity("wikibellum.Entities.Models.Units.Condition", b =>
                {
                    b.Property<string>("ConditionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConditionId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wikibellum.Entities.Event", b =>
                {
                    b.HasOne("wikibellum.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("wikibellum.Entities.BookRecommendation", "Reccomendation")
                        .WithMany()
                        .HasForeignKey("ReccomendationId");
                });

            modelBuilder.Entity("wikibellum.Entities.EventParticipant", b =>
                {
                    b.HasOne("wikibellum.Entities.Event", null)
                        .WithMany("Participants")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("wikibellum.Entities.Models.Units.Asset", b =>
                {
                    b.HasOne("wikibellum.Entities.Models.Units.Classification", "Classification")
                        .WithMany()
                        .HasForeignKey("ClassificationId1");

                    b.HasOne("wikibellum.Entities.Models.Units.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId");

                    b.HasOne("wikibellum.Entities.EventParticipant", null)
                        .WithMany("Losses")
                        .HasForeignKey("EventParticipantId");

                    b.HasOne("wikibellum.Entities.EventParticipant", null)
                        .WithMany("Strength")
                        .HasForeignKey("EventParticipantId1");
                });

            modelBuilder.Entity("wikibellum.Entities.Models.Units.Classification", b =>
                {
                    b.HasOne("wikibellum.Entities.Models.Units.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
