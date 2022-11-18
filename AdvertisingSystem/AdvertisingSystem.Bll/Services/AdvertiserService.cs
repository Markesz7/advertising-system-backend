﻿using AdvertisingSystem.Bll.Dtos;
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
            efAd.Occurence = 0;
            if (efAd.PaymentMethod == "Wallet")
                efAd.TargetOccurence = null;
            _context.Ads.Add(efAd);

            var tls = await _context.Transportlines
                .Where(adtl => (efAd.PlaceGroups.Count == 0 || efAd.PlaceGroups.Contains(adtl.Group)) &&
                               (efAd.StartTime == null || adtl.StartTime >= efAd.StartTime) &&
                               (efAd.EndTime == null || adtl.EndTime <= efAd.EndTime))
                .ToListAsync();

            foreach (var tl in tls)
            {
                _context.AdTransportlines.Add(new AdTransportline { Ad = efAd, Transportline = tl });
            }

            await _context.SaveChangesAsync();
            return await GetAdAsync(efAd.Id);
        }

        public async Task AddMoneyAsync(MoneyDTO advertiser)
        {
            var efAdvertiser = await _context.Advertisers.FirstAsync(x => x.Id == advertiser.Id);
            efAdvertiser.Money += advertiser.Amount;
            _context.Advertisers.Update(efAdvertiser);
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
            var ad = await _context.Ads
                .ProjectTo<AdDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(t => t.Id == adId);
            // TODO : Check for null with exception
            return ad;
        }
    }
}
