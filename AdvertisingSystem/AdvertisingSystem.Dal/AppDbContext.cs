﻿using AdvertisingSystem.Dal.Entities;
using AdvertisingSystem.Dal.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal
{
    //https://stackoverflow.com/questions/49788816
    //If you inherit from the identityUser, we need to add a role class and key type as well in this order
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<Transportline> Transportlines => Set<Transportline>();
        public DbSet<Receipt> Receipts => Set<Receipt>();
        public DbSet<Revenue> Revenues => Set<Revenue>();
        public DbSet<TransportCompany> TransportCompanys => Set<TransportCompany>();
        public DbSet<AdOrganiser> Adorganisers => Set<AdOrganiser>();
        public DbSet<Advertiser> Advertisers => Set<Advertiser>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ad>(builder =>
            {
                builder.Property(a => a.StartTime).HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
                builder.Property(a => a.EndTime).HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            });

            builder.Entity<Transportline>(builder =>
            {
                builder.Property(t => t.StartTime).HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
                builder.Property(t => t.EndTime).HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            });

            // Because now I use the TPH (Table-per-hierarchy) database inheritance, every user is in one table
            // so SQL server thinks if we delete a user, then it has two delete cascade paths (ad and transportline line)
            // For now to fix this, I use restrict delete for the transportlines to break one cascade path.
            // TODO: With Restrict delete, we can't run Update-database 0
            builder.Entity<Transportline>()
                .HasOne(p => p.TransportCompany)
                .WithMany(p => p.Transportlines)
                .HasForeignKey(p => p.TransportCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed test user data
            var appUser = new TransportCompany
            {
                Id = 1,
                Email = "test@test.com",
                EmailConfirmed = true,
                UserName = "t",
            };

            PasswordHasher<TransportCompany> ph = new PasswordHasher<TransportCompany>();
            appUser.PasswordHash = ph.HashPassword(appUser, "123");

            builder.Entity<TransportCompany>().HasData(appUser);

            // Seed test revenue
            builder.Entity<Revenue>().HasData(new Revenue
            {
                Id = 1,
                Date = new DateTime(2000, 1, 1),
                Amount = 5000,
                TransportCompanyId = appUser.Id
            });

        }
    }
}
