using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class Transportline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //TODO: Consider starttime and endtime as a list<TimeOnly>
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        //TODO: Maybe use enums with groups
        public string Group { get; set; }

        //Foreign keys
        public int TransportCompanyId { get; set; }

        //Navigation properties
        public TransportCompany TransportCompany { get; set; } = null!;
        public ICollection<Ad> Ads { get; } = new List<Ad>();

        public Transportline(string name, string group)
        {
            Name = name;
            Group = group;
        }

    }
}
