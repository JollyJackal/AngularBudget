﻿// <auto-generated />
using System;
using AngularBudget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularBudget.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AngularBudget.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("AngularBudget.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AngularBudget.Models.Frequency", b =>
                {
                    b.Property<int>("FrequencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FrequencyId"), 1L, 1);

                    b.Property<string>("FrequencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FrequencyId");

                    b.ToTable("Frequency");

                    b.HasData(
                        new
                        {
                            FrequencyId = 1,
                            FrequencyName = "Days"
                        },
                        new
                        {
                            FrequencyId = 2,
                            FrequencyName = "Weeks"
                        },
                        new
                        {
                            FrequencyId = 3,
                            FrequencyName = "Months"
                        });
                });

            modelBuilder.Entity("AngularBudget.Models.Regularity", b =>
                {
                    b.Property<int>("RegularityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegularityId"), 1L, 1);

                    b.Property<string>("RegularityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegularityId");

                    b.ToTable("Regularity");

                    b.HasData(
                        new
                        {
                            RegularityId = 1,
                            RegularityName = "One Time"
                        },
                        new
                        {
                            RegularityId = 2,
                            RegularityName = "Recurring"
                        });
                });

            modelBuilder.Entity("AngularBudget.Models.UserBill", b =>
                {
                    b.Property<Guid>("UserBillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BillAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrequencyAmount")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEstimate")
                        .HasColumnType("bit");

                    b.Property<int>("RegularityId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserBillCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserBillId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("RegularityId");

                    b.HasIndex("UserBillCompanyId");

                    b.ToTable("UserBill");
                });

            modelBuilder.Entity("AngularBudget.Models.UserBillCompany", b =>
                {
                    b.Property<Guid>("UserBillCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserBillCompanyId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserBillCompany");
                });

            modelBuilder.Entity("AngularBudget.Models.UserBudget", b =>
                {
                    b.Property<Guid>("UserBudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FrequencyAmount")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("int");

                    b.HasKey("UserBudgetId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.HasIndex("FrequencyId");

                    b.ToTable("UserBudget");
                });

            modelBuilder.Entity("AngularBudget.Models.UserIncome", b =>
                {
                    b.Property<Guid>("UserIncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FrequencyAmount")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<int>("IncomeAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("IncomeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IncomeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEstimate")
                        .HasColumnType("bit");

                    b.Property<int>("RegularityId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserIncomeCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserIncomeId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("RegularityId");

                    b.HasIndex("UserIncomeCompanyId");

                    b.ToTable("UserIncome");
                });

            modelBuilder.Entity("AngularBudget.Models.UserIncomeCompany", b =>
                {
                    b.Property<Guid>("UserIncomeCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserIncomeCompanyId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserIncomeCompany");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AngularBudget.Models.UserBill", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserBills")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.Frequency", "BillFrequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.Regularity", "BillRegularity")
                        .WithMany()
                        .HasForeignKey("RegularityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.UserBillCompany", "UserBillCompany")
                        .WithMany()
                        .HasForeignKey("UserBillCompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("BillFrequency");

                    b.Navigation("BillRegularity");

                    b.Navigation("UserBillCompany");
                });

            modelBuilder.Entity("AngularBudget.Models.UserBillCompany", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserBillCompanies")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("AngularBudget.Models.UserBudget", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("UserBudget")
                        .HasForeignKey("AngularBudget.Models.UserBudget", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.Frequency", "BudgetFrequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("BudgetFrequency");
                });

            modelBuilder.Entity("AngularBudget.Models.UserIncome", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserIncomes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.Frequency", "IncomeFrequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.Regularity", "IncomeRegularity")
                        .WithMany()
                        .HasForeignKey("RegularityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.UserIncomeCompany", "UserIncomeCompany")
                        .WithMany()
                        .HasForeignKey("UserIncomeCompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("IncomeFrequency");

                    b.Navigation("IncomeRegularity");

                    b.Navigation("UserIncomeCompany");
                });

            modelBuilder.Entity("AngularBudget.Models.UserIncomeCompany", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserIncomeCompanies")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularBudget.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("AngularBudget.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AngularBudget.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserBillCompanies");

                    b.Navigation("UserBills");

                    b.Navigation("UserBudget")
                        .IsRequired();

                    b.Navigation("UserIncomeCompanies");

                    b.Navigation("UserIncomes");
                });
#pragma warning restore 612, 618
        }
    }
}
