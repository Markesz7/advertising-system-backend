using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal;
using AdvertisingSystem.Dal.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingSystem.Bll.Services
{
    public class TransportCompanyService : ITransportCompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TransportCompanyService(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }

        // TODO: Do this later, this is not well implemented in the database
        public Task DisableAdAsync(RestrictAdDTO ad)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RevenueDTO>> GetRevenuesByCompanyAsync(int userId)
        {
            return await _context.Revenues
                .Where(r => r.TransportCompanyId == userId)
                .ProjectTo<RevenueDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            /*
            return await _context.TransportCompanys
                .Include("Revenues")
                .Where(tc => tc.Id == userId)
                .ProjectTo<RevenueDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            */
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

    }
}
