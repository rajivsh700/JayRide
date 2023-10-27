using JayRide.DTO;
using JayRide.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JayRide.Repository.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        public CandidateDTO GetCandidate()
        {
            var candidate = new CandidateDTO
            {
                Name = "test",
                Phone = "test"
            };
            return candidate;
        }
    }
}
