﻿// <auto-generated />
using System;
using AdvertisingSystem.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdBanTransportline", b =>
                {
                    b.Property<int>("AdBansId")
                        .HasColumnType("int");

                    b.Property<int>("TransportlinesId")
                        .HasColumnType("int");

                    b.HasKey("AdBansId", "TransportlinesId");

                    b.HasIndex("TransportlinesId");

                    b.ToTable("AdBanTransportline");
                });

            modelBuilder.Entity("AdTransportline", b =>
                {
                    b.Property<int>("AdsId")
                        .HasColumnType("int");

                    b.Property<int>("TransportlinesId")
                        .HasColumnType("int");

                    b.HasKey("AdsId", "TransportlinesId");

                    b.HasIndex("TransportlinesId");

                    b.ToTable("AdTransportline");

                    b.HasData(
                        new
                        {
                            AdsId = 2,
                            TransportlinesId = 1
                        });
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdvertiserId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("Occurence")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerializedPlaceGroups")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PlaceGroups");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("AdvertiserId");

                    b.ToTable("Ads");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdURL = "test.com",
                            AdvertiserId = 2,
                            Occurence = 0,
                            PaymentMethod = "Monthly",
                            SerializedPlaceGroups = "Tram"
                        },
                        new
                        {
                            Id = 2,
                            AdURL = "test2.com",
                            AdvertiserId = 2,
                            Occurence = 0,
                            PaymentMethod = "Wallet",
                            SerializedPlaceGroups = "Bus"
                        });
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.AdBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("SerializedVehicleNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("AdId")
                        .IsUnique();

                    b.ToTable("AdBans");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdvertiserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertiserId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Revenue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransportCompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportCompanyId");

                    b.ToTable("Revenues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 5000,
                            Date = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransportCompanyId = 1
                        });
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Transportline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("TransportCompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportCompanyId");

                    b.ToTable("Transportlines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new TimeSpan(0, 16, 27, 0, 0),
                            Group = "Bus",
                            Name = "5A",
                            StartTime = new TimeSpan(0, 15, 42, 0, 0),
                            TransportCompanyId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.AdOrganiser", b =>
                {
                    b.HasBaseType("AdvertisingSystem.Dal.Entities.ApplicationUser");

                    b.HasDiscriminator().HasValue("AdOrganiser");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e4ebbfc0-f3e5-4c92-9ce5-61fbeaa75783",
                            Email = "testAdOrg@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEMQrh13E2BJT6VivUQ5DW1pdTEcK4TH4XKG+ZeQ1XobIdvHLGjtd4s9jHH2fozfHzA==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "t3"
                        });
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Advertiser", b =>
                {
                    b.HasBaseType("AdvertisingSystem.Dal.Entities.ApplicationUser");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Advertiser");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eac2bf9b-5d17-470e-849f-e0e37627760f",
                            Email = "testAdvertiser@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEB644cSmzFrVgfQ2xtRoTeUJAEvXqKUw48xth3xTcYXUZTrnUP1llOIlx1lmOe3gSQ==",
                            PhoneNumberConfirmed = true,
                            TwoFactorEnabled = false,
                            UserName = "t2",
                            Enabled = true,
                            Money = 100
                        });
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.TransportCompany", b =>
                {
                    b.HasBaseType("AdvertisingSystem.Dal.Entities.ApplicationUser");

                    b.HasDiscriminator().HasValue("TransportCompany");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d9aed290-e6fe-497c-9dbd-6722c1f6451e",
                            Email = "test@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEB8DcudtetuG+q/rsMyghMF3GEUkcH1wFXUIfiyZOEWW/J+GZIwltkuuwpigurrBbQ==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "t"
                        });
                });

            modelBuilder.Entity("AdBanTransportline", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.AdBan", null)
                        .WithMany()
                        .HasForeignKey("AdBansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvertisingSystem.Dal.Entities.Transportline", null)
                        .WithMany()
                        .HasForeignKey("TransportlinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdTransportline", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.Ad", null)
                        .WithMany()
                        .HasForeignKey("AdsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvertisingSystem.Dal.Entities.Transportline", null)
                        .WithMany()
                        .HasForeignKey("TransportlinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Ad", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.Advertiser", "Advertiser")
                        .WithMany("Ads")
                        .HasForeignKey("AdvertiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertiser");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.AdBan", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.Ad", "Ad")
                        .WithOne("AdBan")
                        .HasForeignKey("AdvertisingSystem.Dal.Entities.AdBan", "AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Receipt", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.Advertiser", "Advertiser")
                        .WithMany("Receipts")
                        .HasForeignKey("AdvertiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertiser");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Revenue", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.TransportCompany", "TransportCompany")
                        .WithMany("Revenues")
                        .HasForeignKey("TransportCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransportCompany");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Transportline", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.TransportCompany", "TransportCompany")
                        .WithMany("Transportlines")
                        .HasForeignKey("TransportCompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TransportCompany");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvertisingSystem.Dal.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Ad", b =>
                {
                    b.Navigation("AdBan")
                        .IsRequired();
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Advertiser", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.TransportCompany", b =>
                {
                    b.Navigation("Revenues");

                    b.Navigation("Transportlines");
                });
#pragma warning restore 612, 618
        }
    }
}
