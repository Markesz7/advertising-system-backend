using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using AdvertisingSystem.Dal.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Policy = "RequiredAdvertiserRole")]
    public class AdvertiserController : ControllerBase
    {
        private readonly IAdvertiserService _advertiserService;
        //private readonly SignInManager<Advertiser> _signInManager;
        //private readonly UserManager<Advertiser> _userManager;

        public AdvertiserController(IAdvertiserService advertiserService)
        {
            _advertiserService = advertiserService;
        }

        // POST api/<AdvertiserController>/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AdvertiserDTO>> RegisterAdvertiser([FromBody] AdvertiserRegisterDTO advertiser)
        {
            return await _advertiserService.InsertAdvertiserAsync(advertiser);
        }

        // POST api/<AdvertiserController>/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterAdvertiser([FromBody] LoginDTO advertiser)
        {
            var user = await _advertiserService.LoginAdvertiserAsync(advertiser);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "advertiser")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        // POST api/<AdvertiserController>/logout
        [HttpPost("logout")]
        public async Task<ActionResult> LogoutAdvertiser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        // GET api/<AdvertiserController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "RequiredSameID")]
        public async Task<ActionResult<AdvertiserDTO>> GetAdvertiser(int id)
        {
            /*
            var identity = (ClaimsIdentity)User.Identity;
            var identityId = int.Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (identityId != id)
                return StatusCode(403);
            */

            var advertiser = await _advertiserService.GetAdvertiserAsync(id);
            return advertiser;
        }

        // GET api/<AdvertiserController>/5/ads
        [HttpGet("{id}/ads")]
        [Authorize(Policy = "RequiredSameID")]
        public async Task<ActionResult<IEnumerable<AdDTO>>> GetAdsByUser(int id)
        {
            var ads = await _advertiserService.GetAdsByUserAsync(id);
            return ads.ToList();
        }

        // GET api/<AdvertiserController>/5/receipts
        [HttpGet("{id}/receipts")]
        [Authorize(Policy = "RequiredSameID")]
        public async Task<ActionResult<IEnumerable<ReceiptDTO>>> GetReceiptsByUser(int id)
        {
            var receipts = await _advertiserService.GetReceiptsByUser(id);
            return receipts.ToList();
        }

        // POST api/<AdvertiserController>/createad
        [HttpPost("createad")]
        public async Task<ActionResult<AdDTO>> PostAd([FromBody] AdDTO ad)
        {
            var newAd = await _advertiserService.InsertAdAsync(ad);
            return CreatedAtAction(nameof(PostAd), new { Id = newAd.Id }, newAd);
        }

        // POST api/<AdvertiserController>/5/pay
        [HttpPost("{id}/pay")]
        [Authorize(Policy = "RequiredSameID")]
        public async Task<ActionResult<AdDTO>> PostAdMoney(int id, [FromBody] int money)
        {
            await _advertiserService.AddMoneyAsync(id, money);
            return NoContent();
        }
    }
}
