using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using AdvertisingSystem.Dal.Helper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class AdvertiserService : IAdvertiserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private readonly UserManager<Advertiser> _userManager;

        public AdvertiserService(AppDbContext context, IMapper mapper, UserManager<Advertiser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ReceiptDTO>> GetReceiptsByUser(int userId)
        {
            return await _context.Receipts
                .Where(r => r.AdvertiserId == userId)
                .ProjectTo<ReceiptDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AdResponseDTO> InsertAdAsync(AdRequestDTO ad, int advertiserId, string imagePath)
        {
            // TODO: This is kind of a bad solution for this
            ad.ImagePath = imagePath;
            ad.AdURL = $"api/advertiser/{advertiserId}/image/{imagePath.Split("\\").Last()}";
            ad.AdvertiserId = advertiserId;

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

        public async Task AddMoneyAsync(int advertiserId, int money)
        {
            var efAdvertiser = await _context.Advertisers.FirstAsync(x => x.Id == advertiserId);
            efAdvertiser.Money += money;
            _context.Advertisers.Update(efAdvertiser);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdResponseDTO>> GetAdsByUserAsync(int advertiserId)
        {
            return await _context.Ads
                .Where(ad => ad.AdvertiserId == advertiserId)
                .ProjectTo<AdResponseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AdResponseDTO> GetAdAsync(int adId)
        {
            var ad = await _context.Ads
                .ProjectTo<AdResponseDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(t => t.Id == adId);
            // TODO : Check for null with exception
            return ad;
        }

        public async Task<AdvertiserDTO> GetAdvertiserAsync(int advertiserId)
        {
            var advertiser = await _context.Advertisers
                            .ProjectTo<AdvertiserDTO>(_mapper.ConfigurationProvider)
                            .SingleAsync(t => t.Id == advertiserId);

            return advertiser;
        }

        public async Task<AdvertiserDTO> InsertAdvertiserAsync(AdvertiserRegisterDTO advertiser)
        {
            var efAdvertiser = new Advertiser
            {
                UserName = advertiser.UserName,
                Email = advertiser.Email,
                Money = 0,
                Enabled = true
            };
            var result = await _userManager.CreateAsync(efAdvertiser, advertiser.Password);
            if(!result.Succeeded)
            {
                throw new NotImplementedException(result.Errors.First().Description);
            }

            await _userManager.AddToRoleAsync(efAdvertiser, "advertiser");

            return await GetAdvertiserAsync(efAdvertiser.Id);
        }

        public async Task<ApplicationUserDTO> LoginAdvertiserAsync(LoginDTO userCred)
        {
            var user = await _userManager.FindByNameAsync(userCred.UserName);
            if (user == null)
                throw new NotImplementedException("Login failed: Can't find user!");

            if (user.Enabled)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, userCred.Password);
                if (result == PasswordVerificationResult.Failed)
                    throw new NotImplementedException("Login failed: Password is not correct!");

                return _mapper.Map<ApplicationUserDTO>(user);
            }
            else
                throw new NotImplementedException("Login failed: Advertiser is not enabled!");
        }
    }
}
