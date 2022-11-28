namespace AdvertisingSystem.Dal.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }

        //Foreign key
        public int AdvertiserId { get; set; }

        //Navigation properties
        public Advertiser Advertiser { get; set; } = null!;
    }
}
