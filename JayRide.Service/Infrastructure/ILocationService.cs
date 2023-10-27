using JayRide.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JayRide.Service.Infrastructure
{
    public interface ILocationService
    {
        Task<Result<LocationDTO>> GetLocation(string ip, string apiAccessKey);
    }
}
