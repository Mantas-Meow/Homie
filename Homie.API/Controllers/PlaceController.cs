using Microsoft.AspNetCore.Mvc;
using Homie.API.Services.Interfaces;
using Homie.API.DTOs.Place;
using Homie.API.Models;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IItemService _itemService;

        public PlaceController(IPlaceService placeService, IItemService itemService)
        {
            _placeService = placeService;
            _itemService = itemService;
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

        [HttpGet]
        [Route("{id}/Items")]
        public async Task<IActionResult> GetItemsByPlace(Guid placeId)
        {
            var items = _itemService.GetItemsByPlace(placeId);

            if (items != null)
            {
                return Ok(items);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}