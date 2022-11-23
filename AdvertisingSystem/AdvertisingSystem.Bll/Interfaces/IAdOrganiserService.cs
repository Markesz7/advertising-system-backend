using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdOrganiserService
    {
        public Task DeleteAdAsync(int adID);
        public Task<IEnumerable<AdvertiserDTO>> GetAdvertisersAsync();
        public Task ToggleUserAsync(ToggleAdvertiserDTO advertiser);
        public Task DoBookingAsync();
        public Task<ApplicationUserDTO> LoginAdOrganiserAsync(LoginDTO userCred);
    }
}
