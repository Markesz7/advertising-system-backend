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
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }
        //TODO: Maybe use enums with groups
        public string Group { get; set; }

        public Transportline(string name, string group)
        {
            Name = name;
            Group = group;
        }

    }
}
