using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionAttribute;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace MyApi.Controllers
{
    // https://loaclhost:4330/api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // Create new walk
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // map AddWalkRequestDto dto to walk domain model

            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            // map domainmodel to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Get all walks
        // GET:- / api/walks?filterOn=Name?filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var walks = await walkRepository.GetAllAsync(filterOn, filterQuery);

            //map domain model to dto

            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        // Get walk by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update walk by Id
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            // map dto to domain model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // map domain model to dto

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Delete walk by ID
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}