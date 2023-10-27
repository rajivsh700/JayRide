using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JayRide.DTO
{
    public class QuoteRequestDTO
    {
        public string from { get; set; }
       
        public List<ListingDTO> listings { get; set; }
    }
    public class ListingDTO
    {
        public string name { get; set; }
        public decimal totalPrice { get { return pricePerPassenger * vehicleType.maxPassengers; } }
        public decimal pricePerPassenger { get; set; }
        public VehicleTypeDTO vehicleType { get; set; }
    }
    public class VehicleTypeDTO
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }
}
