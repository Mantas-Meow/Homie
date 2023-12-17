using Microsoft.AspNetCore.Mvc;
using Homie.API.DTOs.Item;
using Homie.API.Services;
using Homie.API.Services.Interfaces;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetItem(Guid itemId)
        {
            var item = await _itemService.GetItemById(itemId);

            if(item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }
        /*
         {
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "itemName": "TestItem",
  "description": "TestItem description on how this is a test",
  "placeId": null,
  "lastUpdated": "2023-11-12T13:17:13.358Z",
  "isTaken": false
}
        */
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CreateItemRequestBody item)
        {
            await _itemService.AddItem(item);
            return Ok();
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItem(Guid itemId, [FromBody] UpdateItemRequestBody item)
        {
            await _itemService.UpdateItem(itemId, item);
            return Ok();
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            await _itemService.DeleteItem(itemId);
            return Ok();
        }

        [HttpPost("{itemId}/take")]
        public async Task<IActionResult> TakeItem(Guid itemId)
        {
            await _itemService.TakeItem(itemId);
            return Ok();
        }

        [HttpPost("{itemId}/move/{newPlaceId}")]
        public async Task<IActionResult> MoveItem(Guid itemId, Guid newPlaceId)
        {
            await _itemService.MoveItem(itemId, newPlaceId);
            return Ok();
        }
    }
}