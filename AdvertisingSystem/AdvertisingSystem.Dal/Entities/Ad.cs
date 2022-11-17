using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisingSystem.Dal.Entities
{
    public class Ad
    {
        public int Id { get; set; }
        public int Occurence { get; set; }
        //TODO: maybe do this with enums (probably preferred) or with simple boolean
        public string PaymentMethod { get; set; }
        //Name can't be only URL (and url for parameter), because it causes problems with EF Core
        public string AdURL { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        [Column("PlaceGroups")]
        public string? SerializedPlaceGroups { get; set; }

        // Entity Framework Core doesn't support Lists of primitives as values,
        // therefore we can store the possible answers in a ; seperated list.
        //TODO: Check if this is the right way to check the nullable list
        [NotMapped]
        public List<string>? PlaceGroups
        {
            get
            {
                if(SerializedPlaceGroups != null)
                    return SerializedPlaceGroups.Split(";").ToList();

                return null;
            }

            set
            {
                if (value != null)
                    SerializedPlaceGroups = string.Join(";", value);
                else SerializedPlaceGroups = null;
            }
        }

        //Foreign key
        public int AdvertiserId { get; set; }
        // Only one ID is needed for one-to-one relationship
        //public int AdBanId { get; set; }

        //Navigation properties
        public Advertiser Advertiser { get; set; } = null!;
        // TODO: Consider multiple bans for one ad
        public AdBan? AdBan { get; set; }
        public ICollection<AdTransportline> AdTransportlines { get; } = new List<AdTransportline>();
        public ICollection<Transportline> Transportlines { get; } = new List<Transportline>();

        public Ad(string paymentMethod, string adURL)
        {
            PaymentMethod = paymentMethod;
            AdURL = adURL;

        }
    }
}
