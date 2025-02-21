﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlacementsDriveManagementApp.Interfaces;
using PlacementsDriveManagementApp.Models;

namespace PlacementsDriveManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController: Controller
    {
        private readonly IResumeRepo _resumeRepo;
        private readonly IMapper _mapper;

        public ResumeController(IResumeRepo resumeRepo, IMapper mapper)
        {
            _resumeRepo = resumeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        public IActionResult GetResumes()
        {
            var resumes = _resumeRepo.GetResumes();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(resumes);
        }

        [HttpGet("{resumeId}")]
        [ProducesResponseType(200, Type = typeof(Resume))]
        [ProducesResponseType(400)]
        public IActionResult GetResumeById(int resumeId)
        {
            if (!_resumeRepo.ResumeExists(resumeId))
            {
                return NotFound(ModelState);
            }

            var resume = _resumeRepo.GetResumeById(resumeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resume);
        }

    }
}
