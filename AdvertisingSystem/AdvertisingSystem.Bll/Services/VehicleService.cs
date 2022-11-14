using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VehicleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleAdDTO>> GetAdsAsyncForTransportline(int tlId)
        {
            return await _context.Transportlines
                .Where(tl => tl.Id == tlId)
                .Select(tl => tl.Ads)
                .ProjectTo<VehicleAdDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public Task UploadAdOccurence(IEnumerable<VehicleAdDTO> ads)
        {
            throw new NotImplementedException();
        }
    }
}
