using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class AdvertiserService : IAdvertiserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdvertiserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReceiptDTO>> GetReceiptsByUser(int userId)
        {
            return await _context.Receipts
                .Where(r => r.AdvertiserId == userId)
                .ProjectTo<ReceiptDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AdDTO> InsertAdAsync(AdDTO ad)
        {
            var efAd = _mapper.Map<Ad>(ad);
            _context.Ads.Add(efAd);
            await _context.SaveChangesAsync();
            return await GetAdAsync(efAd.Id);
        }

        public async Task AddMoneyAsync(MoneyDTO advertiser)
        {
            var efAdvertiser = _mapper.Map<Advertiser>(advertiser);
            _context.Advertisers.Attach(efAdvertiser).Property(adv => adv.Money).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdDTO>> GetAdsByUserAsync(int advertiserId)
        {
            return await _context.Ads
                .Where(ad => ad.AdvertiserId == advertiserId)
                .ProjectTo<AdDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AdDTO> GetAdAsync(int adId)
        {
            var ad = await _context.Transportlines
                .ProjectTo<AdDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(t => t.Id == adId);
            // TODO : Check for null with exception
            return ad;
        }
    }
}
