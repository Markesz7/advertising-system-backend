using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IFileService
    {
        public string CurrentRootDirectory { get; set; }
        public Task<string> SaveAdImageAsync(AdRequestDTO ad, int userId);
        public FileStream LoadAdImage(int userId, string adImageId);
        public void DeleteAdImage(int userId, string adImageId);
    }
}
