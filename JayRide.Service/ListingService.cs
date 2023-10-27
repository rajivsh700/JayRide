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
    public class ListingService : IListingService
    {
        public async Task<Result<IEnumerable<ListingDTO>>> GetListings(int passangerNumber)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var quoteRequest = JsonSerializer.Deserialize<QuoteRequestDTO>(result);
                    if(quoteRequest == null) return Result<IEnumerable<ListingDTO>>.Failure("Unable to get the information");
                    var filterListing = quoteRequest.listings.Where(x => x.vehicleType.maxPassengers >= passangerNumber);
                    var sortedList = filterListing.OrderBy(x => x.totalPrice);
                    return Result<IEnumerable<ListingDTO>>.Success(sortedList);

                }
                return Result<IEnumerable<ListingDTO>>.Failure("Something went wrong");

            }

        }
    }
}
