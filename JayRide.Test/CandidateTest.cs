using JayRide.Controllers;
using JayRide.DTO;
using JayRide.Repository.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JayRide.Test
{
    [TestFixture]
    public class CandidateTest
    {
        [Test]
        public void GivenCandidate_WhenGetCandidateIsCalled_ThenReturnCandidateInformation()
        {
            var mockCandidateRepository = new Mock<ICandidateRepository>();
            mockCandidateRepository.Setup(repo => repo.GetCandidate()).Returns(new CandidateDTO { Name = "test", Phone = "test" });
            var controller = new CandidateController(mockCandidateRepository.Object);

            IActionResult actionResult = controller.GetCandidate();

            Assert.NotNull(actionResult);
            OkObjectResult result = actionResult as OkObjectResult;
            Assert.NotNull(result);

            var candidate = result.Value as CandidateDTO;
            Assert.AreEqual("test", candidate.Name);
            Assert.AreEqual("test", candidate.Phone);
        }
    }
}
