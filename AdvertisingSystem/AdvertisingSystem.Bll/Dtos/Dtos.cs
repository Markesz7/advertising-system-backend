using AdvertisingSystem.Dal.Helper;
using System.Text.Json.Serialization;

namespace AdvertisingSystem.Bll.Dtos
{
    public record ApplicationUserDTO(string UserName, string Email, int Id);
    public record AdvertiserRegisterDTO(string UserName, string Password, string Email);
    public record LoginDTO(string UserName, string Password);
    public record RevenueDTO(int Id, DateTime Date, int Amount);
    public record ReceiptDTO(int Id, DateTime Date, int Price);
    public record VehicleDTO(string Secret, IEnumerable<VehicleAdDTO> Ads);
    public record VehicleAdDTO(int Id, int Occurence, string AdURL);
    public record ToggleAdvertiserDTO(int Id, bool Enabled);
    public record MoneyDTO(int Id, int Amount);
    public record AdBanDTO
    {
        public int Id { get; init; }
        [JsonConverter(typeof(TimeOnlyJSONConverter))]
        public TimeOnly? StartTime { get; init; }
        [JsonConverter(typeof(TimeOnlyJSONConverter))]
        public TimeOnly? EndTime { get; init; }
        public List<string> VehicleNames { get; init; } = null!;
        public int AdId { get; set; }
    }

    public record AdvertiserDTO
    {
        public int Id { get; init; }
        public string UserName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public int Money { get; init; }
        public bool Enabled { get; init; }
        public List<AdDTO> Ads { get; init; } = null!;
        public List<ReceiptDTO> Receipts { get; init; } = null!;
    }

    public record AdDTO
    {
        public int? Id { get; init; }
        public int? Occurence { get; init; }
        public int? TargetOccurence { get; init; }
        public string PaymentMethod { get; init; } = null!;
        public string AdURL { get; init; } = null!;
        [JsonConverter(typeof(TimeOnlyJSONConverter))]
        public TimeOnly? StartTime { get; init; }
        [JsonConverter(typeof(TimeOnlyJSONConverter))]
        public TimeOnly? EndTime { get; init; }
        public List<string> PlaceGroups { get; init; } = null!;
        public int AdvertiserId { get; init; }
        public AdBanDTO? AdBan { get; init; }
    }

    public record TransportlineDTO
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        [JsonConverter(typeof(TimeOnlyJSONConverter))]
        public TimeOnly StartTime { get; init; }
        [JsonConverter(typeof(TimeOnlyJSONConverter))]
        public TimeOnly EndTime { get; init; }
        public string Group { get; init; } = null!;
        public int TransportCompanyId { get; init; }
        //public TransportCompany? TransportCompany { get; init; } = null!;
    }
}
