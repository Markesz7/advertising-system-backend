using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdOrganiser : ControllerBase
    {
        private readonly IAdOrganiserService _adOrganiserService;

        public AdOrganiser(IAdOrganiserService adOrganiserService)
        {
            _adOrganiserService = adOrganiserService;
        }

        // GET: api/<AdOrganiser>
        [HttpGet("advertisers")]
        public async Task<ActionResult<IEnumerable<AdvertiserDTO>>> GetAdvertisers()
        {
            var advertiser = await _adOrganiserService.GetAdvertisersAsync();
            return advertiser.ToList();
        }

        // POST api/<AdOrganiser>
        [HttpPost("toggleadvertiser")]
        public async Task<ActionResult> ToggleAdvertiser([FromBody] ToggleAdvertiserDTO advertiser)
        {
            await _adOrganiserService.ToggleUserAsync(advertiser);
            return NoContent();
        }

        // POST api/<AdOrganiser>/dobooking
        [HttpPost("dobooking")]
        public async Task<ActionResult> DoBooking()
        {
            await _adOrganiserService.DoBookingAsync();
            return NoContent();
        }

        // DELETE api/<AdOrganiser>/5
        [HttpDelete("deletead/{id}")]
        public async Task<ActionResult> DeleteAd(int id)
        {
            await _adOrganiserService.DeleteAdAsync(id);
            return NoContent();
        }
    }
}
