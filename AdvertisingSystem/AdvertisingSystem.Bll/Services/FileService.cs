using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal.Entities;
using AdvertisingSystem.Dal.Helper;

namespace AdvertisingSystem.Bll.Services
{
    public class FileService : IFileService
    {
        private string _currentRootDirectory = null!;
        public string CurrentRootDirectory { get => _currentRootDirectory; set => _currentRootDirectory = value; }

        public FileStream LoadAdImage(int userId, string adImageId)
        {
            return File.OpenRead(Path.Combine(_currentRootDirectory, "images", "advertisers", userId.ToString(), adImageId));
        }

        public async Task<string> SaveAdImageAsync(AdRequestDTO ad, int userId)
        {
            var uniqueFileName = FileHelper.GetUniqueFileName(ad.AdImage.FileName);
            var uploadPathWithoutRoot = Path.Combine("images", "advertisers", userId.ToString(), uniqueFileName);
            var uploadPath = Path.Combine(_currentRootDirectory, uploadPathWithoutRoot);
            Directory.CreateDirectory(Path.GetDirectoryName(uploadPath));
            using (FileStream fs = new FileStream(uploadPath, FileMode.Create))
            {
                await ad.AdImage.CopyToAsync(fs);
            }
            return uploadPathWithoutRoot;
        }

        public void DeleteAdImage(int userId, string adImageId)
        {
            var filePath = Path.Combine(_currentRootDirectory, "images", "advertisers", userId.ToString(), adImageId);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
