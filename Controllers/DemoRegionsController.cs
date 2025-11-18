using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace MyApi.Controllers
{
    // https://loaclhost:4330/api/DemoRegions
    [Route("api/[controller]")]
    [ApiController]
    public class DemoRegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region{
                    Id=Guid.NewGuid(),
                    Name="Auckland Region",
                    Code= "AKL",
                    RegionImageUrl = "https://picsum.photos/200/300"
                },
                   new Region{
                    Id=Guid.NewGuid(),
                    Name="Wellington Region",
                    Code= "WLG",
                    RegionImageUrl = "https://picsum.photos/100/300"
                },
            };

            return Ok(regions);
        }
    }
}