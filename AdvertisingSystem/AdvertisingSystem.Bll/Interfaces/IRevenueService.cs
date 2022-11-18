using AdvertisingSystem.Dal.Entities;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IRevenueService
    {
        public Task<IEnumerable<Revenue>> GetRevenuesByMonth();
        public Task InsertRevenue(Revenue revenue);
        public Task DeleteRevenue(int revenueId);
    }
}
