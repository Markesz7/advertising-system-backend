using AdvertisingSystem.Bll.Dtos;
using AdvertisingSystem.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvertisingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertiserController : ControllerBase
    {
        private readonly IAdvertiserService _advertiserService;

        public AdvertiserController(IAdvertiserService advertiserService)
        {
            _advertiserService = advertiserService;
        }

        // GET api/<AdvertiserController>/register
        [HttpPost("register")]
        public async Task<ActionResult<AdvertiserDTO>> RegisterAdvertiser([FromBody] AdvertiserRegisterDTO advertiser)
        {
            return await _advertiserService.InsertAdvertiserAsync(advertiser);
        }

        // GET api/<AdvertiserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertiserDTO>> GetAdvertiser(int id)
        {
            var advertiser = await _advertiserService.GetAdvertiserAsync(id);
            return CreatedAtAction(nameof(GetAdvertiser), new { Id = advertiser.Id }, advertiser);
        }

        // GET api/<AdvertiserController>/5/ads
        [HttpGet("{id}/ads")]
        public async Task<ActionResult<IEnumerable<AdDTO>>> GetAdsByUser(int id)
        {
            var ads = await _advertiserService.GetAdsByUserAsync(id);
            return ads.ToList();
        }

        // GET api/<AdvertiserController>/5/receipts
        [HttpGet("{id}/receipts")]
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
        public async Task<ActionResult<AdDTO>> PostAdMoney(int id, [FromBody] int money)
        {
            await _advertiserService.AddMoneyAsync(id, money);
            return NoContent();
        }
    }
}
