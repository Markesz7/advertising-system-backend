using AdvertisingSystem.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingSystem.Bll.Interfaces
{
    public interface ITransportlineService
    {
        public Task<Transportline> GetTransportlineAsync();
        public Task<IEnumerable<Transportline>> GetTransportlinesAsync();
        public Task<Transportline> InsertTransportlineAsync(Transportline transportline);
        public Task UpdateTransportlineAsync(int tlId, Transportline transportline);
        public Task DeleteTransportlineAsync(int tlId);
    }
}
