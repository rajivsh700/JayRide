using JayRide.Controllers;
using JayRide.DTO;
using JayRide.Service;
using JayRide.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class LocationTest
    {
        private IConfiguration _configuration { get; set; }

        [SetUp]
        public void Setup()
        {
            // Set up an in-memory configuration for the tests
            var inMemorySettings = new Dictionary<string, string>
            {
                { "AccessKey:ApiAccessKey", "f2421b571a41d7284c186266006f247c" }
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }
        [Test]
        public async Task GivenLocation_WhenGetLocationIsCalled_ThenReturnOK()
        {

            // Arrange
            var ip = "134.201.250.155";
            var apiAccessKey = "f2421b571a41d7284c186266006f247c";
            var mockLocationService = new Mock<ILocationService>();
          
            var expectedResult = Result<LocationDTO>.Success(new LocationDTO { continent_name = "continent_name", country_code= "country_code", country_name= "country_name" });
            mockLocationService.Setup(service => service.GetLocation(ip, apiAccessKey)).ReturnsAsync(expectedResult);
            var controller = new LocationController(_configuration, mockLocationService.Object);

            // Act
            var result = await controller.GetLocation(ip);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        // can add more test cases as needed
    }
}
