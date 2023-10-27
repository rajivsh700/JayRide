using JayRide.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JayRide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseApiController
    {
        private readonly IConfiguration _config;
        private readonly ILocationService _locationService;
        public LocationController(IConfiguration config, ILocationService locationService)
        {
            _config = config;
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocation([FromQuery] string ip)
        {
            var apiAccessKey = _config.GetValue<string>("AccessKey:ApiAccessKey");
            var result = await _locationService.GetLocation(ip, apiAccessKey);
            return HandleResult(result);
        }
    }
}
