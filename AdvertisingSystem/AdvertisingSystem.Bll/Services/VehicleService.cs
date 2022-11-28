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

        public async Task<IEnumerable<VehicleAdDTO>> GetAdsForTransportlineAsync(int tlId)
        {
            var ads = await _context.AdTransportlines
                .Where(adtl => adtl.TransportlineId == tlId && (adtl.AdBan == null || adtl.AdBan.SubstituteAdURL != null))
                .Where(adtl => adtl.Ad.PaymentMethod != "Wallet" || adtl.Ad.Advertiser.Money > 0)
                .ProjectTo<VehicleAdDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return ads;
        }

        /* This is not the best a solution for performance, but for test data, it works.
         * Possible solutions for later (this essentialy needs a bulk update):
         * 1. Update to EF Core 7 (released at the beginning of 2022 Nov), which supports bulk update, but this can break other stuff
         * 2. Add the Z.EntityFramework.Plus.EFCore nuget package, which supports bulk update, but this needs a lot of dependency updates
         * 3. Search for an elegant raw SQL command solution
         */
        public async Task UploadAdOccurence(IEnumerable<VehicleAdDTO> ads)
        {
            var adsIDList = ads.Select(ad => ad.Id).ToList();
            var selectedAds = await _context.Ads
                .Include(x => x.Advertiser)
                .Where(ad => adsIDList.Contains(ad.Id)).ToListAsync();

            foreach (var ad in selectedAds)
            {
                var adOccurence = ads.Where(x => x.Id == ad.Id).First().Occurence;

                if (ad.PaymentMethod == "Wallet")
                {
                    ad.Advertiser.Money -= adOccurence * 100;
                }
                ad.Occurence += adOccurence;
            }

            await _context.SaveChangesAsync();
        }
    }
}
