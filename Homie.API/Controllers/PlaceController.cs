using Microsoft.AspNetCore.Mvc;
using Homie.API.Services.Interfaces;
using Homie.API.DTOs.Place;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/places")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public IActionResult GetPlaces()
        {
            var places = _placeService.GetPlaces();
            return Ok(places);
        }

        [HttpGet("{placeId}")]
        public IActionResult GetPlace(Guid placeId)
        {
            var place = _placeService.GetPlaceById(placeId);

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
        public IActionResult AddPlace([FromBody] CreatePlaceRequestBody place)
        {
            _placeService.AddPlace(place);
            return Ok();
        }

        [HttpPut("{placeId}")]
        public IActionResult UpdatePlace(Guid placeId, [FromBody] UpdatePlaceRequestBody place)
        {
            _placeService.UpdatePlace(placeId, place);
            return Ok();
        }

        [HttpDelete("{placeId}")]
        public IActionResult DeletePlace(Guid placeId)
        {
            _placeService.DeletePlace(placeId);
            return Ok();
        }
    }
}