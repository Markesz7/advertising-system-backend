using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // POST: api/<VehicleController>/5
        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<VehicleAdDTO>>> GetAdsForTransportline(int id, [FromBody] string secret)
        {
            if (secret != "123")
                return StatusCode(403);
            return (await _vehicleService.GetAdsForTransportlineAsync(id)).ToList();
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<ActionResult> PostAdOccurences([FromBody] VehicleDTO request)
        {
            if (request.Secret != "123")
                return StatusCode(403);

            await _vehicleService.UploadAdOccurence(request.Ads);
            return NoContent();
        }
    }
}
