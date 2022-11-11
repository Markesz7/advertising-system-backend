using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface ITransportCompanyService
    {
        public Task<IEnumerable<RevenueDTO>> GetReceiptsByCompanyAsync(int userId);
        public Task<TransportlineDTO> InsertTransportlineAsync(TransportlineDTO transportline);
        public Task DisableAdAsync(RestrictAdDTO ad);
    }
}
