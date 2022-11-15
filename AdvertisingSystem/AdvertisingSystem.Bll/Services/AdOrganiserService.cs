using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class AdOrganiserService : IAdOrganiserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdOrganiserService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task DeleteAdAsync(int adID)
        {
            _context.Ads.Remove(new Ad(null!, null!) { Id = adID });
            await _context.SaveChangesAsync();
        }

        // TODO
        public Task DoBookingAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ToggleUserAsync(ToggleAdvertiserDTO advertiser)
        {
            var efAdvertiser = _mapper.Map<Advertiser>(advertiser);
            _context.Entry(efAdvertiser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdvertiserDTO>> GetAdvertisersAsync()
        {
            return await _context.Advertisers
                .ProjectTo<AdvertiserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
