namespace AdvertisingSystem.Dal.Entities
{
    public class Advertiser : ApplicationUser
    {
        public int Money { get; set; }
        public bool Enabled { get; set; }

        //Navigation properties
        public ICollection<Ad> Ads { get; } = new List<Ad>();
        public ICollection<Receipt> Receipts { get; } = new List<Receipt>();
    }
}
