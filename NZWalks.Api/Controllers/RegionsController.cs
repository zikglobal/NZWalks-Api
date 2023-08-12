using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Model.Domain;
using NZWalks.Api.Model.DTO;
using NZWalks.Api.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            this. dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        public NZWalksDbContext DbContext { get; }
        // GET ALL REGIONS
        //GET : https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
           var regionsDomain = await regionRepository.GetAllAsync();

            //Return DTOs
            return Ok (mapper.Map<List<RegionDto>>(regionsDomain));
        }

        //GET A SINGLE REGION ( GET REGION BY ID ) 
        //GET : https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task <IActionResult> GetById([FromRoute] Guid id) 
        {

           // var regionDomain = dbContext.Regions.Find(id);
           // Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to Client
            return Ok (mapper.Map<RegionDto>(regionDomain));
             
                
            
        }
        //POST to Create new Region
        //POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map to Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Domain Model To Create New Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain Model Back To DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }

        // Update region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) 
        {
            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            //Check if region exists 

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //Convert Domain Model To DTO

            return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }
        // Delete a Region
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete("{id:Guid}")]
        public async Task <IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Return deleted region back
            // Map Doamin Model to DTO
           
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

    }
}
