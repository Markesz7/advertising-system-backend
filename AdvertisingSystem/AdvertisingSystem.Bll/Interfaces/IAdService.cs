using AdvertisingSystem.Dal.Entities;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IAdService
    {
        public Task<Ad> GetAdAsync(int adId);
        public Task<IEnumerable<Ad>> GetAdsAsync();
        public Task<Ad> InsertAdAsync();
        public Task UpdateAdAsync(int adId, Ad ad);
        public Task DeleteAdAsync(int adId);
        public Task UploadAdOccurenceAsync(IEnumerable<Ad> ads);
    }
}
