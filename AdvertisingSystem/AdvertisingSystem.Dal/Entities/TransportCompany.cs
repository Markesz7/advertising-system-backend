using Microsoft.AspNetCore.Identity;

namespace AdvertisingSystem.Dal.Entities
{
    public class TransportCompany : ApplicationUser
    {
        //Naviagtion properties
        public ICollection<Transportline> Transportlines { get; } = new List<Transportline>();
        public ICollection<Revenue> Revenues { get; } = new List<Revenue>();
    }
}
