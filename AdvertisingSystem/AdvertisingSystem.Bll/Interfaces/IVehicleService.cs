using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleAdDTO>> GetAdsForTransportlineAsync(int tlId);
        public Task UploadAdOccurence(IEnumerable<VehicleAdDTO> ads);
    }
}
