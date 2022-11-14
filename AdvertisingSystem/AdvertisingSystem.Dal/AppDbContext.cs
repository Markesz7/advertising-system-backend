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

        protected override async void OnModelCreating(ModelBuilder builder)
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

            await Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Transportlines]");

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

            // Seed test ads
            Ad ad1 = new Ad("Monthly", "test.com")
            {
                Id = 1,
                PlaceGroups = new List<string>() { "Tram" },
                Occurence = 0,
                AdvertiserId = 5
            };

            Ad ad2 = new Ad("Wallet", "test2.com")
            {
                Id = 2,
                PlaceGroups = new List<string>() { "Bus" },
                Occurence = 0,
                AdvertiserId = 5
            };

            // Seed test Transportline
            Transportline tl = new Transportline("5A", "Bus")
            {
                Id = 1,
                StartTime = new TimeOnly(15, 42),
                EndTime = new TimeOnly(16, 27),
                TransportCompanyId = 1
            };

        }
    }
}
