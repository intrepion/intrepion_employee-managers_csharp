﻿// <auto-generated />
using System;
using Intrepion.EmployeeManagers.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Intrepion.EmployeeManagers.BusinessLogic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTest")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.EmployeeManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.ToTable("EmployeeManagers");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoleClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUsers")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.Employee", "Employee")
                        .WithOne("ApplicationUser")
                        .HasForeignKey("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserLogins")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserTokens")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.Employee", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedEmployees")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.EmployeeManager", b =>
                {
                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedEmployeeManagers")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.Employee", "Employee")
                        .WithMany("EmployeeManagers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.EmployeeManagers.BusinessLogic.Entities.Employee", "Manager")
                        .WithMany("ManagerEmployees")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");

                    b.Navigation("Employee");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("UpdatedApplicationRoleClaims");

                    b.Navigation("UpdatedApplicationRoles");

                    b.Navigation("UpdatedApplicationUserClaims");

                    b.Navigation("UpdatedApplicationUserLogins");

                    b.Navigation("UpdatedApplicationUserRoles");

                    b.Navigation("UpdatedApplicationUserTokens");

                    b.Navigation("UpdatedApplicationUsers");

                    b.Navigation("UpdatedEmployeeManagers");

                    b.Navigation("UpdatedEmployees");
                });

            modelBuilder.Entity("Intrepion.EmployeeManagers.BusinessLogic.Entities.Employee", b =>
                {
                    b.Navigation("ApplicationUser");

                    b.Navigation("EmployeeManagers");

                    b.Navigation("ManagerEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
