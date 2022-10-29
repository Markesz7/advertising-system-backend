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
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        //Foreign keys
        public int TransportCompanyId { get; set; }
        public int AdOrganiserId { get; set; }

        //Navigation properties
        public TransportCompany? TransportCompany { get; set; }
        public AdOrganiser? AdOrganiser { get; set; }
    }
}
