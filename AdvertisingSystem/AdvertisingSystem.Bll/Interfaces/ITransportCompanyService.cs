using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface ITransportCompanyService
    {
        public Task<IEnumerable<RevenueDTO>> GetRevenuesByCompanyAsync(int userId);
        public Task<TransportlineDTO> InsertTransportlineAsync(TransportlineDTO transportline);
        public Task<AdBanDTO> BanAdAsync(AdBanDTO adban);
        public Task<AdBanDTO> GetAdBanAsync(int adbanId);
        public Task EnableAdAsync(int adbanId);
        public Task<TransportlineDTO> GetTransportlineAsync(int tlId);
    }
}
