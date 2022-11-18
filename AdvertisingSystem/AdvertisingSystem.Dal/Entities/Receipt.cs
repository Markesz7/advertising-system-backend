namespace AdvertisingSystem.Dal.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }

        //Foreign key
        //public int AdId { get; set; }
        public int AdvertiserId { get; set; }

        //Navigation properties
        //public Ad Ad { get; set; } = null!;
        public Advertiser Advertiser { get; set; } = null!;
    }
}
