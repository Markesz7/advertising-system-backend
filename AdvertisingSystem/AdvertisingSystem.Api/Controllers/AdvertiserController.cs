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

        // GET api/<AdvertiserController>/5
        [HttpGet("ads/{id}")]
        public async Task<ActionResult<IEnumerable<AdDTO>>> GetAdsByUser(int id)
        {
            var ads = await _advertiserService.GetAdsByUserAsync(id);
            return ads.ToList();
        }

        // GET api/<AdvertiserController>/receipts/5
        [HttpGet("receipts/{id}")]
        public async Task<ActionResult<IEnumerable<ReceiptDTO>>> GetReceiptsByUser(int id)
        {
            var receipts = await _advertiserService.GetReceiptsByUser(id);
            return receipts.ToList();
        }

        // POST api/<AdvertiserController>/PostAd
        [HttpPost("createad")]
        public async Task<ActionResult<AdDTO>> PostAd([FromBody] AdDTO ad)
        {
            var newAd = await _advertiserService.InsertAdAsync(ad);
            return CreatedAtAction(nameof(PostAd), new { Id = newAd.Id }, newAd);
        }

        // POST api/<AdvertiserController>/pay
        [HttpPost("pay")]
        public async Task<ActionResult<AdDTO>> PostAdMoney([FromBody] MoneyDTO money)
        {
            await _advertiserService.AddMoneyAsync(money);
            return NoContent();
        }
    }
}
