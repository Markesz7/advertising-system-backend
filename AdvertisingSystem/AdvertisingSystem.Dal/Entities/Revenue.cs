using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class Revenue
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }
        public int amount { get; set; }
    }
}
