namespace AdvertisingSystem.Dal.Entities
{
    public class Transportline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        //TODO: Maybe use enums with groups
        public string Group { get; set; }

        //Foreign keys
        public int? TransportCompanyId { get; set; }

        //Navigation properties
        public TransportCompany? TransportCompany { get; set; }
        public ICollection<AdTransportline> AdTrnasportlines { get; } = new List<AdTransportline>();
        public ICollection<Ad> Ads { get; } = new List<Ad>();
        //public ICollection<AdBan> AdBans { get; } = new List<AdBan>();

        public Transportline(string name, string group)
        {
            Name = name;
            Group = group;
        }

    }
}
