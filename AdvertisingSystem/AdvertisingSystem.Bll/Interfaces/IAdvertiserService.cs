using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdvertiserService
    {
        public Task<AdDTO> InsertAdAsync(AdDTO ad);
        public Task<IEnumerable<ReceiptDTO>> GetReceiptsByUser(int userId);
        public Task AddMoneyAsync(MoneyDTO advertiser);
        public Task<AdDTO> GetAdAsync(int adId);
        public Task<IEnumerable<AdDTO>> GetAdsByUserAsync(int advertiserId);
    }
}
