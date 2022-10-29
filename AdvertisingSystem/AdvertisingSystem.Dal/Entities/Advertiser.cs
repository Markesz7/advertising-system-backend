using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class Advertiser : ApplicationUser
    {
        public int Money { get; set; }
        public bool Enabled { get; set; }

        //Navigation properties
        public IEnumerable<Ad> Ads { get; } = new List<Ad>();
        public IEnumerable<Receipt> Receipts { get; } = new List<Receipt>();
    }
}
