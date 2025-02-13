﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlacementsDriveManagementApp.Dto;
using PlacementsDriveManagementApp.Interfaces;
using PlacementsDriveManagementApp.Models;

namespace PlacementsDriveManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningController: Controller
    {
        private readonly IOpeningRepo _openingRepo;
        private readonly IMapper _mapper;

        public OpeningController(IOpeningRepo openingRepo, IMapper mapper)
        {
            _openingRepo = openingRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Opening>))]
        public IActionResult GetOpenings()
        {
            var openings = _mapper.Map<List<OpeningDto>>(_openingRepo.GetOpenings());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(openings);
        }

        [HttpGet("{openingId}")]
        [ProducesResponseType(200, Type = typeof(Opening))]
        [ProducesResponseType(400)]
        public IActionResult GetOpeningById(int openingId)
        {
            if (!_openingRepo.OpeningExists(openingId))
            {
                return NotFound(ModelState);
            }

            var opening = _mapper.Map<OpeningDto>(_openingRepo.GetOpeningById(openingId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(opening);
        }

        [HttpGet("{openingId}/company")]
        [ProducesResponseType(200, Type = typeof(Company))]
        [ProducesResponseType(400)]
        public IActionResult GetCompanyByOpening(int openingId)
        {
            if (!_openingRepo.OpeningExists(openingId))
            {
                return NotFound(ModelState);
            }

            var company = _mapper.Map<CompanyDto>(_openingRepo.GetCompanyByOpening(openingId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(company);
        }

        [HttpGet("{openingId}/applications")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Application>))]
        [ProducesResponseType(400)]
        public IActionResult GetApplicationsByOpening(int openingId)
        {
            if (!_openingRepo.OpeningExists(openingId))
            {
                return NotFound(ModelState);
            }

            var applications = _mapper.Map<List<ApplicationDto>>(_openingRepo.GetApplicationsByOpening(openingId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(applications);
        }

    }
}
