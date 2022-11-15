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

        // GET api/<TransportCompanyController>/5
        [HttpGet("revenues/{id}")]
        public async Task<ActionResult<IEnumerable<RevenueDTO>>> GetRevenues(int id)
        {
            return (await _transportCompanyService.GetRevenuesByCompanyAsync(id)).ToList();
        }

        // POST api/<TransportCompanyController>
        [HttpPost("createtransportline")]
        public async Task<ActionResult<TransportlineDTO>> InsertTransportline([FromBody] TransportlineDTO transportline)
        {
            var newTransportline = await _transportCompanyService.InsertTransportlineAsync(transportline);
            return CreatedAtAction(nameof(InsertTransportline), new { id = newTransportline.Id }, newTransportline);
        }
    }
}
