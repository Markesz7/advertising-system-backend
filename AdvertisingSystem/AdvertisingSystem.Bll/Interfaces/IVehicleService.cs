using AdvertisingSystem.Bll.Dtos;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleAdDTO>> GetAdsAsyncForTransportline(int tlId);
        public Task UploadAdOccurence(IEnumerable<VehicleAdDTO> ads);
    }
}
