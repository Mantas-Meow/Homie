using Microsoft.AspNetCore.Mvc;
using Homie.API.Services.Interfaces;
using Homie.API.DTOs.Place;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            var places = await _placeService.GetPlaces();
            return Ok(places);
        }

        [HttpGet("{placeId}")]
        public async Task<IActionResult> GetPlace(Guid placeId)
        {
            var place = await _placeService.GetPlaceById(placeId);

            if(place != null)
            {
                return Ok(place);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPlace([FromBody] CreatePlaceRequestBody place)
        {
            await _placeService.AddPlace(place);
            return Ok();
        }

        [HttpPut("{placeId}")]
        public async Task<IActionResult> UpdatePlace(Guid placeId, [FromBody] UpdatePlaceRequestBody place)
        {
            await _placeService.UpdatePlace(placeId, place);
            return Ok();
        }

        [HttpDelete("{placeId}")]
        public async Task<IActionResult> DeletePlace(Guid placeId)
        {
            await _placeService.DeletePlace(placeId);
            return Ok();
        }
    }
}