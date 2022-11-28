using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Exceptions;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class AdOrganiserService : IAdOrganiserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        private readonly UserManager<AdOrganiser> _userManager;

        public AdOrganiserService(IMapper mapper, AppDbContext context, UserManager<AdOrganiser> userManager, IFileService fileService)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task DeleteAdAsync(int adID)
        {
            _context.Ads.Remove(new Ad(null!, null!, null!) { Id = adID });
            await _context.SaveChangesAsync();
        }

        public async Task DoBookingAsync()
        {
            #nullable disable
            var transportCompany = await _context.TransportCompanys.FirstAsync();
            var adOrganizer = await _context.Adorganisers.FirstAsync();

            var ads = await _context.Ads.ToListAsync();

            int adPrice = 100;
            int totalOccurence = 0;
            Dictionary<int, int> moneyDictionary = new Dictionary<int, int>();
            foreach(var ad in ads)
            {
                totalOccurence += ad.Occurence;

                if(ad.PaymentMethod == "Monthly")
                {
                    var RemainingOcc = (int)ad.TargetOccurence - ad.Occurence;

                    var receipt = new Receipt
                    {
                        AdvertiserId = ad.AdvertiserId,
                        Date = DateTime.Now,
                        Price = (int)(RemainingOcc <= 0 ?
                                ad.TargetOccurence * adPrice :
                                (ad.TargetOccurence * adPrice) - (RemainingOcc * adPrice))
                    };

                    _context.Receipts.Add(receipt);

                    if(RemainingOcc > 0)
                    {
                        if (moneyDictionary.ContainsKey(ad.AdvertiserId))
                            moneyDictionary[ad.AdvertiserId] += moneyDictionary[ad.AdvertiserId] + RemainingOcc * adPrice;
                        else moneyDictionary.Add(ad.AdvertiserId, RemainingOcc * adPrice);
                    }

                    _context.Ads.Remove(ad);
                    _fileService.DeleteAdImage(ad.AdvertiserId, ad.ImagePath.Split("/").Last());
                }
                ad.Occurence = 0;
            }

            // TransportCompany - AdOrganiser will get 50-50% revenue
            var revenue = new Revenue
            {
                TransportCompanyId = transportCompany.Id,
                Amount = totalOccurence * adPrice / 2,
                Date = DateTime.Now
            };
            _context.Revenues.Add(revenue);

            var advertisers = await _context.Advertisers.Where(x => moneyDictionary.Keys.Contains(x.Id)).ToListAsync();
            foreach(var advertiser in advertisers)
            {
                advertiser.Money += moneyDictionary[advertiser.Id];
            }
            _context.UpdateRange(advertisers);
            await _context.SaveChangesAsync();
        }

        public async Task ToggleUserAsync(ToggleAdvertiserDTO advertiser)
        {
            var efAdvertiser = await _context.Advertisers.SingleOrDefaultAsync(x => x.Id == advertiser.Id);
            efAdvertiser.Enabled = advertiser.Enabled;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdvertiserDTO>> GetAdvertisersAsync()
        {
            return await _context.Advertisers
                .ProjectTo<AdvertiserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ApplicationUserDTO> LoginAdOrganiserAsync(LoginDTO userCred)
        {
            var user = await _userManager.FindByNameAsync(userCred.UserName);
            if (user == null)
                throw new FailedLoginOrRegisterException("Login failed: Can't find user!");

            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, userCred.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new FailedLoginOrRegisterException("Login failed: Password is not correct!");

            return _mapper.Map<ApplicationUserDTO>(user);
        }
    }
}
