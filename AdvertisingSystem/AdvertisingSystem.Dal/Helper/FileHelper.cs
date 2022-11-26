namespace AdvertisingSystem.Dal.Helper
{
    public class FileHelper
    {
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return string.Concat(Guid.NewGuid().ToString().AsSpan(0, 8), Path.GetExtension(fileName));
        }
    }
}
