using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportCompanyController : ControllerBase
    {
        private readonly ITransportCompanyService _transportCompanyService;

        public TransportCompanyController(ITransportCompanyService transportCompanyService)
        {
            _transportCompanyService = transportCompanyService;
        }

        // GET api/<TransportCompanyController>/5/transportlines
        [HttpGet("{id}/transportlines")]
        public async Task<ActionResult<IEnumerable<TransportlineDTO>>> GetTransportlines(int id)
        {
            return (await _transportCompanyService.GetTransportlinesAsync(id)).ToList();
        }

        // GET api/<TransportCompanyController>/5/revenues
        [HttpGet("{id}/revenues")]
        public async Task<ActionResult<IEnumerable<RevenueDTO>>> GetRevenues(int id)
        {
            return (await _transportCompanyService.GetRevenuesByCompanyAsync(id)).ToList();
        }

        // POST api/<TransportCompanyController>/createtransportline
        [HttpPost("createtransportline")]
        public async Task<ActionResult<TransportlineDTO>> InsertTransportline([FromBody] TransportlineDTO transportline)
        {
            var newTransportline = await _transportCompanyService.InsertTransportlineAsync(transportline);
            return CreatedAtAction(nameof(InsertTransportline), new { id = newTransportline.Id }, newTransportline);
        }

        // POST api/<TransportCompanyController>/addadban
        [HttpPost("addadban")]
        public async Task<ActionResult<AdBanDTO>> BanAd([FromBody] AdBanDTO adban)
        {
            // TODO: This logic should not be here
            if (adban.VehicleNames.Count == 0 && (adban.StartTime == null || adban.EndTime == null))
                return BadRequest();

            var newAdBan = await _transportCompanyService.BanAdAsync(adban);
            return CreatedAtAction(nameof(BanAd), new { id = newAdBan.Id }, newAdBan);
        }

        // DELETE api/<TransportCompanyController>/deleteadban
        [HttpDelete("deleteadban/{id}")]
        public async Task<ActionResult<AdBanDTO>> EnableAd(int id)
        {
            await _transportCompanyService.EnableAdAsync(id);
            return NoContent();
        }
    }
}
