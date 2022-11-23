using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Policy = "RequiredAdOrganiserRole")]
    public class AdOrganiser : ControllerBase
    {
        private readonly IAdOrganiserService _adOrganiserService;

        public AdOrganiser(IAdOrganiserService adOrganiserService)
        {
            _adOrganiserService = adOrganiserService;
        }

        // POST api/<AdOrganiser>/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApplicationUserDTO>> LoginTransportCompany([FromBody] LoginDTO transportCompany)
        {
            var user = await _adOrganiserService.LoginAdOrganiserAsync(transportCompany);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "adorganiser")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return user;
        }

        // POST api/<AdOrganiser>/logout
        [HttpPost("logout")]
        public async Task<ActionResult> LogoutTransportCompany()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
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
