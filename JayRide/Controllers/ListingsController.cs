using JayRide.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JayRide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : BaseApiController
    {
        private readonly IListingService _listingService;
        public ListingsController(IListingService listingService)
        {
            _listingService = listingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetListings([FromQuery] int passengerNumber)
        {            
            var result = await _listingService.GetListings(passengerNumber);
            return HandleResult(result);
        }
    }
}
