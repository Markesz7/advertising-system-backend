using AdvertisingSystem.Dal.Entities;

namespace AdvertisingSystem.Bll.Dtos
{
    public record RevenueDTO(int Id, DateTime Date, int Amount);
    public record ReceiptDTO(int Id, DateTime Date, int Price);
    public record VehicleAdDTO(int Id, int Occurence, string AdURL);
    public record RestrictAdDTO(int Id, bool Enabled, string AdURL);
    public record RestrictAdvertiserDTO(int Id, bool Enabled);
    public record MoneyDTO(int Id, int Amount);
    public record AdvertiserDTO
    {
        public int Id { get; init; }
        public string UserName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public int Money { get; init; }
        public bool Enabled { get; init; }
        public List<Ad> Ads { get; init; } = null!;
        public List<Receipt> Receipts { get; init; } = null!;
    }

    public record AdDTO
    {
        public int Id { get; init; }
        public int Occurence { get; init; }
        public string PaymentMethod { get; init; } = null!;
        public string AdURL { get; init; } = null!;
        public TimeOnly? StartTime { get; init; }
        public TimeOnly? EndTime { get; init; }
        public List<string>? PlaceGroups = null!;
        public int AdvertiserId { get; init; }
        public Advertiser Advertiser { get; init; } = null!;
    }
    public record TransportlineDTO
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
        public string Group { get; init; } = null!;
        public int TransportCompanyId { get; init; }
        public TransportCompany TransportCompany { get; init; } = null!;
    }
}
