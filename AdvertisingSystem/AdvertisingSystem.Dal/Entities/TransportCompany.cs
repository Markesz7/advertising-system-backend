using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Dal.Entities
{
    public class TransportCompany : ApplicationUser
    {
        //Naviagtion properties
        public ICollection<Transportline> Transportlines { get; } = new List<Transportline>();
        public ICollection<Revenue> Revenues { get; } = new List<Revenue>();
    }
}
