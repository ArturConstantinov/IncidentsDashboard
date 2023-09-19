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
    [Migration("20230919121540_AddedAmbitsToTypesTableAndOriginsToAmbitAndChangedIncidentsForeignKeys")]
    partial class AddedAmbitsToTypesTableAndOriginsToAmbitAndChangedIncidentsForeignKeys
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

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("Ambits");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.AmbitsToTypes", b =>
                {
                    b.Property<int>("AmbitId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("AmbitId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("AmbitsToTypes");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmbitId")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginId")
                        .IsRequired()
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

                    b.Property<int>("ScenaryId")
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
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ThirdParty")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ThreatId")
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

                    b.HasIndex("AmbitId");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("OriginId");

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
                            RequestNr = "host0000007415837",
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"));

                    b.ToTable("IncidentTypes");
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

            modelBuilder.Entity("Incidents.Domain.Entities.OriginsToAmbit", b =>
                {
                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("AmbitId")
                        .HasColumnType("int");

                    b.HasKey("OriginId", "AmbitId");

                    b.HasIndex("AmbitId");

                    b.ToTable("OriginsToAmbit");
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

            modelBuilder.Entity("Incidents.Domain.Entities.AmbitsToTypes", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.Ambit", "IncidentAmbit")
                        .WithMany("AmbitsToTypes")
                        .HasForeignKey("AmbitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.IncidentType", "IncidentType")
                        .WithMany("AmbitsToTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IncidentAmbit");

                    b.Navigation("IncidentType");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Incident", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.Ambit", "Ambit")
                        .WithMany("Incidents")
                        .HasForeignKey("AmbitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.IncidentType", "IncidentType")
                        .WithMany("Incidents")
                        .HasForeignKey("IncidentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.Origin", "Origin")
                        .WithMany("Incidents")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.Scenary", "Scenary")
                        .WithMany()
                        .HasForeignKey("ScenaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.Threat", "Threat")
                        .WithMany()
                        .HasForeignKey("ThreatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambit");

                    b.Navigation("IncidentType");

                    b.Navigation("Origin");

                    b.Navigation("Scenary");

                    b.Navigation("Threat");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.OriginsToAmbit", b =>
                {
                    b.HasOne("Incidents.Domain.Entities.Ambit", "Ambit")
                        .WithMany("OriginsToAmbits")
                        .HasForeignKey("AmbitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Incidents.Domain.Entities.Origin", "Origin")
                        .WithMany("OriginsToAmbits")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ambit");

                    b.Navigation("Origin");
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

            modelBuilder.Entity("Incidents.Domain.Entities.Ambit", b =>
                {
                    b.Navigation("AmbitsToTypes");

                    b.Navigation("Incidents");

                    b.Navigation("OriginsToAmbits");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.IncidentType", b =>
                {
                    b.Navigation("AmbitsToTypes");

                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("Incidents.Domain.Entities.Origin", b =>
                {
                    b.Navigation("Incidents");

                    b.Navigation("OriginsToAmbits");
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
