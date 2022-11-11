using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdvertiserService
    {
        public Task<AdDTO> InsertAdAsync(AdDTO ad);
        public Task<IEnumerable<ReceiptDTO>> GetReceiptsByUser(int userId);
        public Task UploadMoneyAsync(MoneyDTO advertiser);
    }
}
