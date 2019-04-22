﻿

namespace Vote.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;

    using Vote.Web.Data;

    [Route("api/[Controller]")]
    public class CandidatesController : Controller
    {
        private readonly ICandidateRepository candidateRepository;

        public CandidatesController(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
  
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(this.candidateRepository.GetallWithUsers());

        }
    }
}
