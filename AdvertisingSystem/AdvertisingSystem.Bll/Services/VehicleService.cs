﻿using AdvertisingSystem.Bll.Dtos;
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
                .Select(tl => tl.Ads) // The select is needed because we only want to convert the Ads, not the whole object
                .ProjectTo<VehicleAdDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /* This is not good a solution a performance is bad as well, but for test data, it works.
         * Possible solutions for later (this essentialy needs a bulk update):
         * 1. Update to EF Core 7 (released at the beginning of 2022 Nov), which supports bulk update, but this can break other stuff
         * 2. Add the Z.EntityFramework.Plus.EFCore nuget package, which supports bulk update, but this needs a lot of dependency updates
         * 3. Search for an elegant raw SQL command solution
         */
        public async Task UploadAdOccurence(IEnumerable<VehicleAdDTO> ads)
        {
            var adsIDList = ads.Select(ad => ad.Id).ToList();
            var selectedAds = await _context.Ads
                .Where(ad => adsIDList.Contains(ad.Id)).ToListAsync();
            foreach(var ad in selectedAds)
            {
                ad.Occurence += ads.Where(x => x.Id == ad.Id).First().Occurence;
            }
        }
    }
}
