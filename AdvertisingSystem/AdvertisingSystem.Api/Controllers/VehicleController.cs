using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IFileService _fileService;

        public VehicleController(IVehicleService vehicleService, IFileService fileService)
        {
            _vehicleService = vehicleService;
            _fileService = fileService;
        }

        // POST api/<VehicleController>/5/image/46d359f1
        [HttpPost("{advertiserid}/image/{adPictureId}")]
        public ActionResult GetImage(int advertiserid, string adPictureId, [FromBody] string secret)
        {
            if (secret != "secretstring")
                return StatusCode(403);

            var image = _fileService.LoadAdImage(advertiserid, adPictureId);
            return File(image, "image/jpeg");
        }

        // POST: api/<VehicleController>/5
        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<VehicleAdDTO>>> GetAdsForTransportline(int id, [FromBody] string secret)
        {
            if (secret != "secretstring")
                return StatusCode(403);
            return (await _vehicleService.GetAdsForTransportlineAsync(id)).ToList();
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<ActionResult> PostAdOccurences([FromBody] VehicleDTO request)
        {
            if (request.Secret != "secretstring")
                return StatusCode(403);

            await _vehicleService.UploadAdOccurence(request.Ads);
            return NoContent();
        }
    }
}
