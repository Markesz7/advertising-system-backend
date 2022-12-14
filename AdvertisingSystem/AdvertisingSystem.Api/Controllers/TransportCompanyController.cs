using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AdvertisingSystem.Bll.Services;
using AdvertisingSystem.Dal.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Policy = "RequiredTransportCompanyRole")]
    public class TransportCompanyController : ControllerBase
    {
        private readonly ITransportCompanyService _transportCompanyService;
        private readonly IFileService _fileService;

        public TransportCompanyController(ITransportCompanyService transportCompanyService, IFileService fileService)
        {
            _transportCompanyService = transportCompanyService;
            _fileService = fileService;
        }

        // POST api/<TransportCompanyController>/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApplicationUserDTO>> LoginTransportCompany([FromBody] LoginDTO transportCompany)
        {
            var user = await _transportCompanyService.LoginTransportCompanyAsync(transportCompany);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "transportcompany")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return user;
        }

        // POST api/<TransportCompanyController>/logout
        [HttpPost("logout")]
        public async Task<ActionResult> LogoutTransportCompany()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        // GET api/<TransportCompanyController>/5/transportlines
        [HttpGet("{id}/transportlines")]
        [Authorize(Policy = "RequiredSameID")]
        public async Task<ActionResult<IEnumerable<TransportlineDTO>>> GetTransportlines(int id)
        {
            return (await _transportCompanyService.GetTransportlinesAsync(id)).ToList();
        }

        // GET api/<TransportCompanyController>/5/revenues
        [HttpGet("{id}/revenues")]
        [Authorize(Policy = "RequiredSameID")]
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

        // GET api/<TransportCompanyController>/ads
        [HttpGet("ads")]
        public async Task<ActionResult<IEnumerable<AdResponseDTO>>> GetAds()
        {
            return (await _transportCompanyService.GetAdsAsync()).ToList();
        }

        // POST api/<TransportCompanyController>/addadban
        [HttpPost("addadban")]
        [RequestSizeLimit(15 * 1024 * 1024)]
        public async Task<ActionResult<AdBanDTO>> BanAd([FromForm] AdBanDTO adban)
        {
            // TODO: This logic should not be here
            if (adban.VehicleNames.Count == 0 && (adban.StartTime == null || adban.EndTime == null))
                return BadRequest();

            string adpath = "";
            if(adban.SubstituteAdImage != null)
                adpath = await _fileService.SaveAdImageAsync(adban.SubstituteAdImage, adban.AdvertiserId);

            var newAdBan = await _transportCompanyService.BanAdAsync(adban, adpath);
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
