using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
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

        // GET: api/<VehicleController>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VehicleAdDTO>>> GetAdsForTransportline(int id)
        {
            return (await _vehicleService.GetAdsAsyncForTransportline(id)).ToList();
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<ActionResult> PostAdOccurences([FromBody] IEnumerable<VehicleAdDTO> ads)
        {
            await _vehicleService.UploadAdOccurence(ads);
            return NoContent();
        }
    }
}
