using AdvertisingSystem.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IRevenueService
    {
        public Task<IEnumerable<Revenue>> GetRevenuesByMonth();
        public Task InsertRevenue(Revenue revenue);
        public Task DeleteRevenue(int revenueId);
    }
}
