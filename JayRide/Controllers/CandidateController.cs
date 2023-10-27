using JayRide.Repository.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JayRide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
       
        private readonly ICandidateRepository _candidateRepository;
        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        [HttpGet]
        public IActionResult GetCandidate()
        {
            var result = _candidateRepository.GetCandidate();
            return Ok(result);
        }
    }
}
