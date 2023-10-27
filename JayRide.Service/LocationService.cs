using JayRide.DTO;
using JayRide.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JayRide.Service
{
    public class LocationService : ILocationService
    {
        public async Task<Result<LocationDTO>> GetLocation(string ip, string apiAccessKey)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = $"http://api.ipstack.com/{ip}?access_key={apiAccessKey}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();                
                    var location = JsonSerializer.Deserialize<LocationDTO>(result);
                    if (location == null || location.continent_name==null) return Result<LocationDTO>.Failure("Unable to get the location information");
                    return Result<LocationDTO>.Success(location);
                }
                return Result<LocationDTO>.Failure("Something went wrong");
               
            }
                
        }
    }
}
