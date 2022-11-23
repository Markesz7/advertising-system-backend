using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using AdvertisingSystem.Dal.Helper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class TransportCompanyService : ITransportCompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private readonly UserManager<TransportCompany> _userManager;

        public TransportCompanyService(AppDbContext appDbContext, IMapper mapper, UserManager<TransportCompany> userManager)
        {
            _context = appDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AdBanDTO> BanAdAsync(AdBanDTO adban)
        {
            var efAdban = _mapper.Map<AdBan>(adban);
            await GetTransportlinesByNamesAndTimerangeAsync(efAdban);

            _context.AdBans.Add(efAdban);
            await _context.SaveChangesAsync();
            return await GetAdBanAsync(efAdban.Id);
        }

        public async Task<AdBanDTO> GetAdBanAsync(int adbanId)
        {
            // TODO: Check for null reference
            return await _context.AdBans
                .ProjectTo<AdBanDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(adban => adban.Id == adbanId);
        }

        public async Task EnableAdAsync(int adbanId)
        {
            var adtls = await _context.AdTransportlines
                .Where(adtl => adtl.AdBanId == adbanId).ToListAsync();

            foreach(var adtl in adtls)
            {
                adtl.AdBanId = null;
            }
            _context.AdTransportlines.UpdateRange(adtls);
            _context.AdBans.Remove(new AdBan() { Id = adbanId });
            await _context.SaveChangesAsync();
        }

        public async Task GetTransportlinesByNamesAndTimerangeAsync(AdBan adban)
        {
            List<AdTransportline> results;
            if(adban.StartTime != null && adban.VehicleNames.Count != 0)
            {
                results = await _context.AdTransportlines
                    .Where(x => x.Transportline.StartTime >= adban.StartTime &&
                                x.Transportline.EndTime <= adban.EndTime && 
                                adban.VehicleNames.Contains(x.Transportline.Name))
                    .ToListAsync();
            }
            else if(adban.VehicleNames.Count != 0)
            {
                results = await _context.AdTransportlines
                    .Where(x => adban.VehicleNames.Contains(x.Transportline.Name))
                    .ToListAsync();
            }
            else
            {
                results = await _context.AdTransportlines
                    .Where(x => x.Transportline.StartTime >= adban.StartTime && 
                                x.Transportline.EndTime <= adban.EndTime)
                    .ToListAsync();
            }
            adban.AdTransportlines.AddRange(results);
        }

        public async Task<IEnumerable<RevenueDTO>> GetRevenuesByCompanyAsync(int userId)
        {
            return await _context.Revenues
                .Where(r => r.TransportCompanyId == userId)
                .ProjectTo<RevenueDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TransportlineDTO> GetTransportlineAsync(int tlId)
        {
            var transportline = await _context.Transportlines
                .ProjectTo<TransportlineDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(t => t.Id == tlId);
            // TODO : Check for null with exception
            return transportline;
        }

        public async Task<TransportlineDTO> InsertTransportlineAsync(TransportlineDTO transportline)
        {
            var efTransportline = _mapper.Map<Transportline>(transportline);
            // TODO: Is AddAsync necessary here?
            await _context.Transportlines.AddAsync(efTransportline);
            await _context.SaveChangesAsync();
            return await GetTransportlineAsync(efTransportline.Id);
        }

        public async Task<IEnumerable<TransportlineDTO>> GetTransportlinesAsync(int tlId)
        {
            var transportlines = await _context.Transportlines
                .Where(t => t.Id == tlId)
                .ProjectTo<TransportlineDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return transportlines;
        }

        public async Task<ApplicationUserDTO> LoginTransportCompanyAsync(LoginDTO userCred)
        {
            var user = await _userManager.FindByNameAsync(userCred.UserName);
            if (user == null)
                throw new NotImplementedException("Login failed: Can't find user!");

            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, userCred.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new NotImplementedException("Login failed: Password is not correct!");

            return _mapper.Map<ApplicationUserDTO>(user);
        }
    }
}
