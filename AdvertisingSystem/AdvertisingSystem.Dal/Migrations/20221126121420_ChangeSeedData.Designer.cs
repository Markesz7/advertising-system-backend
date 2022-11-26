﻿// <auto-generated />
using System;
using AdvertisingSystem.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvertisingSystem.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221126121420_ChangeSeedData")]
    partial class ChangeSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int?>("TargetOccurence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertiserId");

                    b.ToTable("Ads");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdURL = "api/advertiser/3/image/abc123de",
                            AdvertiserId = 3,
                            ImagePath = "images/advertisers/3/abc123de.jpg",
                            Occurence = 0,
                            PaymentMethod = "Monthly",
                            SerializedPlaceGroups = "Tram",
                            TargetOccurence = 30
                        },
                        new
                        {
                            Id = 2,
                            AdURL = "api/advertiser/3/image/cba321ed",
                            AdvertiserId = 3,
                            ImagePath = "images/advertisers/3/cba321ed.jpg",
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

                    b.Property<string>("SubstituteAdURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdId")
                        .IsUnique();

                    b.ToTable("AdBans");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.AdTransportline", b =>
                {
                    b.Property<int>("AdId")
                        .HasColumnType("int");

                    b.Property<int>("TransportlineId")
                        .HasColumnType("int");

                    b.Property<int?>("AdBanId")
                        .HasColumnType("int");

                    b.HasKey("AdId", "TransportlineId");

                    b.HasIndex("AdBanId");

                    b.HasIndex("TransportlineId");

                    b.ToTable("AdTransportlines");

                    b.HasData(
                        new
                        {
                            AdId = 2,
                            TransportlineId = 1
                        });
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

                    b.Property<int?>("TransportCompanyId")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "d105a3f8-8326-4d0b-8702-1dd05b1c292f",
                            Name = "transportcompany",
                            NormalizedName = "TRANSPORTCOMPANY"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "06c1866d-8342-4058-9ca8-becf48af5801",
                            Name = "adorganizer",
                            NormalizedName = "ADORGANIZER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "6bd546e5-1692-4b65-a9d3-d5a42eafd0df",
                            Name = "advertiser",
                            NormalizedName = "ADVERTISER"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
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
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7b706058-f07d-46b7-b1a2-d83f01dba513",
                            Email = "testAdOrg@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "TESTADORG",
                            PasswordHash = "AQAAAAEAACcQAAAAED00lMiLz0oNYn+i73c2E4mZFJoWVmztgAZY/T8fMFzm9LZXqMgwXjP1kSHWZuQ/+g==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testadorg"
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
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6bc0efe3-7962-449e-bea3-e8d0680fdec5",
                            Email = "testAdvertiser@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "TESTADV",
                            PasswordHash = "AQAAAAEAACcQAAAAEE31gxXLX7K2sdroaRxdUN5g2jR1UQdM/m3M28PnA0N9FHKEY00dVcc6QHLiwky3TA==",
                            PhoneNumberConfirmed = true,
                            TwoFactorEnabled = false,
                            UserName = "testadv",
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
                            ConcurrencyStamp = "8303402d-e1ed-4936-b424-d22add72841f",
                            Email = "test@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "TESTTC",
                            PasswordHash = "AQAAAAEAACcQAAAAEANl+Xw3L5h+TnawJ5nsRXDIDwrbMjMFBJBbsEhWuwD6LQEDAYbiW1YPACIZbLP5Cg==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "testtc"
                        });
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

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.AdTransportline", b =>
                {
                    b.HasOne("AdvertisingSystem.Dal.Entities.AdBan", "AdBan")
                        .WithMany("AdTransportlines")
                        .HasForeignKey("AdBanId");

                    b.HasOne("AdvertisingSystem.Dal.Entities.Ad", "Ad")
                        .WithMany("AdTransportlines")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvertisingSystem.Dal.Entities.Transportline", "Transportline")
                        .WithMany("AdTrnasportlines")
                        .HasForeignKey("TransportlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("AdBan");

                    b.Navigation("Transportline");
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
                        .HasForeignKey("TransportCompanyId");

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
                    b.Navigation("AdBan");

                    b.Navigation("AdTransportlines");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.AdBan", b =>
                {
                    b.Navigation("AdTransportlines");
                });

            modelBuilder.Entity("AdvertisingSystem.Dal.Entities.Transportline", b =>
                {
                    b.Navigation("AdTrnasportlines");
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
