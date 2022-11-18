namespace AdvertisingSystem.Dal.Entities
{
    public class Revenue
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        //Foreign keys
        public int TransportCompanyId { get; set; }

        //Navigation properties
        public TransportCompany? TransportCompany { get; set; }
    }
}
