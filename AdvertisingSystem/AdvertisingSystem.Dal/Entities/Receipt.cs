using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }
        public int price { get; set; }
    }
}
