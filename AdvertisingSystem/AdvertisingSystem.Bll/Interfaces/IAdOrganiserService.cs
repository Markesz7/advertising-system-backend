using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdOrganiserService
    {
        public Task DeleteAdAsync(int adID);
        public Task<IEnumerable<AdvertiserDTO>> GetAdvertisersAsync();
        public Task EnableUserAsync(RestrictAdvertiserDTO advertiser);
        public Task DoBookingAsync();
    }
}
