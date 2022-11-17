using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisingSystem.Dal.Entities
{
    public class AdTransportline
    {
        public int AdId { get; set; }
        public int TransportlineId { get; set; }
        public int? AdBanId { get; set; }

        // Navigation properties
        public AdBan? AdBan { get; set; }
        public Ad Ad { get; set; } = null!;
        public Transportline Transportline { get; set; } = null!;
        
    }
}
