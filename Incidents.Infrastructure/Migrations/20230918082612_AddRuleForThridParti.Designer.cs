﻿// <auto-generated />
using System;
using Incidents.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Incidents.Infrastructure.Migrations
{
    [DbContext(typeof(IncidentsDbContext))]
    [Migration("20230918082612_AddRuleForThridParti")]
    partial class AddRuleForThridParti
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Incidents.Domain.Entities.Ambit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.HasIndex("OriginId");

                    b.ToTable("Ambits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Software",
                            OriginId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Functionality",
                            OriginId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phase",
                            OriginId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Release",
                            OriginId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Service",
                            OriginId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Functionality",
                            OriginId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Software",
                            OriginId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Transmission Channels",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 9,
                            Name = "CICS",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 10,
                            Name = "Database",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 11,
                            Name = "Phase",
                            OriginId = 1
                        },
                        new
                        {
                            Id = 12,
                            Name = "Hardware Host",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 13,
                            Name = "Hardware Open",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 14,
                            Name = "Middleware",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 15,
                            Name = "Networks",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 16,
                            Name = "Security",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 17,
                            Name = "Software",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 18,
                            Name = "Basic Host Software",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 19,
                            Name = "Open Basic Software",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 20,
                            Name = "Service Software",
                            OriginId = 3
                        },
                        new
                        {
                            Id = 21,
                            Name = "Storage",
                            OriginId = 3
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmbitId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("IncidentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int");

                    b.Property<string>("ProblemDescription")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("ProblemSummery")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RequestNr")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int?>("ScenaryId")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SubCause")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Subsystem")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ThirdParty")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ThreatId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Urgency")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("RequestNr")
                        .IsUnique();

                    b.HasIndex("ScenaryId");

                    b.HasIndex("ThreatId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmbitId = 3,
                            ApplicationType = "Application Type",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            IncidentTypeId = 1,
                            OpenDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OriginId = 1,
                            ProblemDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            ProblemSummery = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            RequestNr = "host00007415837",
                            ScenaryId = 1,
                            Solution = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            SubCause = "definition change",
                            Subsystem = "cr",
                            ThirdParty = "AAA1",
                            ThreatId = 1,
                            Type = "Request Intervention",
                            Urgency = "Hight"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.IncidentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmbitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("AmbitId");

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("IncidentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmbitId = 3,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 2,
                            AmbitId = 3,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 3,
                            AmbitId = 11,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 4,
                            AmbitId = 11,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 5,
                            AmbitId = 2,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 6,
                            AmbitId = 6,
                            Name = "Third Parts"
                        },
                        new
                        {
                            Id = 7,
                            AmbitId = 4,
                            Name = "Incorrect Change"
                        },
                        new
                        {
                            Id = 8,
                            AmbitId = 1,
                            Name = "Incorrect Change"
                        },
                        new
                        {
                            Id = 9,
                            AmbitId = 1,
                            Name = "Code"
                        },
                        new
                        {
                            Id = 10,
                            AmbitId = 1,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 11,
                            AmbitId = 1,
                            Name = "Resource Saturation"
                        },
                        new
                        {
                            Id = 12,
                            AmbitId = 7,
                            Name = "Third Parts"
                        },
                        new
                        {
                            Id = 13,
                            AmbitId = 17,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 14,
                            AmbitId = 5,
                            Name = "Third Parts"
                        },
                        new
                        {
                            Id = 15,
                            AmbitId = 8,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 16,
                            AmbitId = 8,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 17,
                            AmbitId = 8,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 18,
                            AmbitId = 9,
                            Name = "Hardware Malfunction"
                        },
                        new
                        {
                            Id = 19,
                            AmbitId = 9,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 20,
                            AmbitId = 10,
                            Name = "Degradation"
                        },
                        new
                        {
                            Id = 21,
                            AmbitId = 10,
                            Name = "Hardware Malfunction"
                        },
                        new
                        {
                            Id = 22,
                            AmbitId = 10,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 23,
                            AmbitId = 10,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 24,
                            AmbitId = 12,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 25,
                            AmbitId = 12,
                            Name = "Resource Saturation"
                        },
                        new
                        {
                            Id = 26,
                            AmbitId = 13,
                            Name = "Incorrect Change"
                        },
                        new
                        {
                            Id = 27,
                            AmbitId = 13,
                            Name = "Block"
                        },
                        new
                        {
                            Id = 28,
                            AmbitId = 13,
                            Name = "Degradation"
                        },
                        new
                        {
                            Id = 29,
                            AmbitId = 13,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 30,
                            AmbitId = 14,
                            Name = "Incorrect Change"
                        },
                        new
                        {
                            Id = 31,
                            AmbitId = 14,
                            Name = "Software Malfunction"
                        },
                        new
                        {
                            Id = 32,
                            AmbitId = 14,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 33,
                            AmbitId = 14,
                            Name = "Resource Saturation"
                        },
                        new
                        {
                            Id = 34,
                            AmbitId = 15,
                            Name = "Incorrect Change"
                        },
                        new
                        {
                            Id = 35,
                            AmbitId = 16,
                            Name = "Accesses"
                        },
                        new
                        {
                            Id = 36,
                            AmbitId = 16,
                            Name = "Cyber Attacks"
                        },
                        new
                        {
                            Id = 37,
                            AmbitId = 16,
                            Name = "Certificates"
                        },
                        new
                        {
                            Id = 38,
                            AmbitId = 16,
                            Name = "Configuration"
                        },
                        new
                        {
                            Id = 39,
                            AmbitId = 16,
                            Name = "Firewall"
                        },
                        new
                        {
                            Id = 40,
                            AmbitId = 16,
                            Name = "IDM"
                        },
                        new
                        {
                            Id = 41,
                            AmbitId = 16,
                            Name = "Patching"
                        },
                        new
                        {
                            Id = 42,
                            AmbitId = 18,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 43,
                            AmbitId = 19,
                            Name = "Insufficient Resources"
                        },
                        new
                        {
                            Id = 44,
                            AmbitId = 19,
                            Name = "Resource Saturation"
                        },
                        new
                        {
                            Id = 45,
                            AmbitId = 20,
                            Name = "Block"
                        },
                        new
                        {
                            Id = 46,
                            AmbitId = 20,
                            Name = "Degradation"
                        },
                        new
                        {
                            Id = 47,
                            AmbitId = 20,
                            Name = "Resource Saturation"
                        },
                        new
                        {
                            Id = 48,
                            AmbitId = 21,
                            Name = "Resource Saturation"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Origins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Application"
                        },
                        new
                        {
                            Id = 2,
                            Name = "External"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Infrastructure"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "User that can add, modify and disable other users, change data manually.",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "User that can import data from a CSV file.",
                            Name = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            Description = "User that can can view information about incidents.",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Scenary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Scenarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "A2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "A3"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Threat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Threats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AA1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AA2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AA3"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0,
                            Email = "admin@mail.com",
                            FullName = "Admin",
                            IsEnabled = true,
                            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            UserName = "cr00001"
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Ambit", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Incident", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.IncidentType", "IncidentType")
                        .WithMany()
                        .HasForeignKey("IncidentTypeId");

                    b.HasOne("Incidents.Domain.Entities.Scenary", "Scenary")
                        .WithMany()
                        .HasForeignKey("ScenaryId");

                    b.HasOne("Incidents.Domain.Entities.Threat", "Threat")
                        .WithMany()
                        .HasForeignKey("ThreatId");

                    b.Navigation("IncidentType");

                    b.Navigation("Scenary");

                    b.Navigation("Threat");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.IncidentType", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.Ambit", "Ambit")
                        .WithMany()
                        .HasForeignKey("AmbitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambit");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
