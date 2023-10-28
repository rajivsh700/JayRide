using JayRide.Controllers;
using JayRide.DTO;
using JayRide.Service;
using JayRide.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JayRide.Test
{
    public class ListingTest
    {
        [Test]
        public async Task GivenListing_WhenGetListingsIsCalledWithPassengerNumber_ThenReturnValidListing()
        {
            var listingService = new Mock<IListingService>();

            var listing = new List<ListingDTO>
            {
                new ListingDTO
                {
                    name ="test",
                    pricePerPassenger=10,
                    vehicleType= new VehicleTypeDTO()
                    {
                        name="test",
                        maxPassengers=10
                    }

                },
                new ListingDTO
                {
                    name = "test1",
                    pricePerPassenger = 5,
                    vehicleType = new VehicleTypeDTO()
                    {
                        name = "test",
                        maxPassengers = 5
                    }

                }

            };

            var expectedResult = Result<IEnumerable<ListingDTO>>.Success(listing);
            listingService.Setup(l => l.GetListings(5)).ReturnsAsync(expectedResult);

            var controller = new ListingsController(listingService.Object);

            var result = await controller.GetListings(5);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }
    }

    // can add more test cases as needed
}
