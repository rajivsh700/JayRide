using JayRide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JayRide.Service.Infrastructure
{
    public interface IListingService
    {
        Task<Result<IEnumerable<ListingDTO>>> GetListings(int passangerNumber);
    }
}
