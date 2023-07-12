using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Model.Domain;
using System.Reflection.Metadata.Ecma335;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
           this. dbContext = dbContext;
        }

        public NZWalksDbContext DbContext { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
           var regions = dbContext.Regions.ToList();


            return Ok (regions);
        }
       
    }
}
