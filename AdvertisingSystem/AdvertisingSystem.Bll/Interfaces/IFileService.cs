using AdvertisingSystem.Bll.Dtos;
using Microsoft.AspNetCore.Http;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IFileService
    {
        public string CurrentRootDirectory { get; set; }
        public Task<string> SaveAdImageAsync(IFormFile image, int userId);
        public FileStream LoadAdImage(int userId, string adImageId);
        public void DeleteAdImage(int userId, string adImageId);
    }
}
