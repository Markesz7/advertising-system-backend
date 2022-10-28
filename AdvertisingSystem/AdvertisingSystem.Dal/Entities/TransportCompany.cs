using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class TransportCompany
    {
        //Naviagtion properties
        public IEnumerable<Transportline> Transportlines { get; } = new List<Transportline>();
        public IEnumerable<Revenue> Revenues { get; } = new List<Revenue>();
    }
}
