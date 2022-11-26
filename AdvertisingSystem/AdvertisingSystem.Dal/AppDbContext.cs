using AdvertisingSystem.Dal.Entities;
using AdvertisingSystem.Dal.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<AdBan> AdBans => Set<AdBan>();
        public DbSet<AdTransportline> AdTransportlines => Set<AdTransportline>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite keys must be configured with fluent API in EF core
            builder.Entity<Ad>()
                .HasMany(ad => ad.Transportlines)
                .WithMany(tl => tl.Ads)
                .UsingEntity<AdTransportline>(
                    j => j
                        .HasOne(adtl => adtl.Transportline)
                        .WithMany(t => t.AdTrnasportlines)
                        .HasForeignKey(adtl => adtl.TransportlineId),
                    j => j
                        .HasOne(adtl => adtl.Ad)
                        .WithMany(ad => ad.AdTransportlines)
                        .HasForeignKey(adtl => adtl.AdId),
                    j =>
                    {
                        j.HasKey(table => new { table.AdId, table.TransportlineId });
                    });

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

            builder.Entity<AdBan>(builder =>
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
                .OnDelete(DeleteBehavior.ClientSetNull);

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            SeedRoles(builder);

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();

            // Seed test user data
            var tc = new TransportCompany
            {
                Id = 1,
                Email = "test@test.com",
                EmailConfirmed = true,
                UserName = "testtc",
                NormalizedUserName = "TESTTC"
            };
            tc.PasswordHash = ph.HashPassword(tc, "123");
            builder.Entity<TransportCompany>().HasData(tc);

            AdOrganiser adOrg = new AdOrganiser
            {
                Id = 2,
                Email = "testAdOrg@test.com",
                EmailConfirmed = true,
                UserName = "testadorg",
                NormalizedUserName = "TESTADORG"
            };
            adOrg.PasswordHash = ph.HashPassword(adOrg, "345");
            builder.Entity<AdOrganiser>().HasData(adOrg);

            Advertiser adv = new Advertiser
            {
                Id = 3,
                Email = "testAdvertiser@test.com",
                EmailConfirmed = true,
                UserName = "testadv",
                NormalizedUserName = "TESTADV",
                Money = 100,
                Enabled = true,
                PhoneNumberConfirmed = true
            };
            adv.PasswordHash = ph.HashPassword(adv, "234");
            builder.Entity<Advertiser>().HasData(adv);

            // Seed test revenue
            builder.Entity<Revenue>().HasData(new Revenue
            {
                Id = 1,
                Date = new DateTime(2000, 1, 1),
                Amount = 5000,
                TransportCompanyId = tc.Id
            });

            // Seed test ads
            Ad ad1 = new Ad("Monthly", $"api/advertiser/{adv.Id}/image/abc123de", $"images/advertisers/{adv.Id}/abc123de.jpg")
            {
                Id = 1,
                PlaceGroups = new List<string>() { "Tram" },
                Occurence = 0,
                TargetOccurence = 30,
                AdvertiserId = adv.Id
            };

            Ad ad2 = new Ad("Wallet", $"api/advertiser/{adv.Id}/image/cba321ed", $"images/advertisers/{adv.Id}/cba321ed.jpg")
            {
                Id = 2,
                PlaceGroups = new List<string>() { "Bus" },
                Occurence = 0,
                AdvertiserId = adv.Id
            };
            builder.Entity<Ad>().HasData(ad1, ad2);

            // Seed test Transportline
            Transportline tl = new Transportline("5A", "Bus")
            {
                Id = 1,
                StartTime = new TimeOnly(15, 42),
                EndTime = new TimeOnly(16, 27),
                TransportCompanyId = 1
            };
            builder.Entity<Transportline>().HasData(tl);
          
            builder.Entity<AdTransportline>().HasData(new AdTransportline
            {
                AdId = 2,
                TransportlineId = 1
            });

            SeedUsersToRoles(builder);
        }

        private void SeedUsersToRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 2
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 3,
                UserId = 3
            });
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 1,
                Name = "transportcompany",
                NormalizedName = "TRANSPORTCOMPANY"
            });

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 2,
                Name = "adorganizer",
                NormalizedName = "ADORGANIZER"
            });

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 3,
                Name = "advertiser",
                NormalizedName = "ADVERTISER"
            });

        }
    }
}
