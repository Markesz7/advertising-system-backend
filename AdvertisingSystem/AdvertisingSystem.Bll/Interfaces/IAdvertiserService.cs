using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdvertiserService
    {
        public Task<AdResponseDTO> InsertAdAsync(AdRequestDTO ad, int advertiserId, string imagePath);
        public Task<IEnumerable<ReceiptDTO>> GetReceiptsByUser(int userId);
        public Task AddMoneyAsync(int advertiserId, int money);
        public Task<AdResponseDTO> GetAdAsync(int adId);
        public Task<IEnumerable<AdResponseDTO>> GetAdsByUserAsync(int advertiserId);
        public Task<AdvertiserDTO> GetAdvertiserAsync(int advertiserId);
        public Task<AdvertiserDTO> InsertAdvertiserAsync(AdvertiserRegisterDTO advertiser);
        public Task<ApplicationUserDTO> LoginAdvertiserAsync(LoginDTO userCred);
    }
}
