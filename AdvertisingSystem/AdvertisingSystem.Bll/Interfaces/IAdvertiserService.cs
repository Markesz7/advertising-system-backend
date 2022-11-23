using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdvertiserService
    {
        public Task<AdDTO> InsertAdAsync(AdDTO ad);
        public Task<IEnumerable<ReceiptDTO>> GetReceiptsByUser(int userId);
        public Task AddMoneyAsync(int advertiserId, int money);
        public Task<AdDTO> GetAdAsync(int adId);
        public Task<IEnumerable<AdDTO>> GetAdsByUserAsync(int advertiserId);
        public Task<AdvertiserDTO> GetAdvertiserAsync(int advertiserId);
        public Task<AdvertiserDTO> InsertAdvertiserAsync(AdvertiserRegisterDTO advertiser);
    }
}
