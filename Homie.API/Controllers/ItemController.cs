using Microsoft.AspNetCore.Mvc;
using Homie.API.DTOs.Item;
using Homie.API.Services;
using Homie.API.Services.Interfaces;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(Guid itemId)
        {
            var item = _itemService.GetItemById(itemId);

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
        public IActionResult AddItem([FromBody] CreateItemRequestBody item)
        {
            _itemService.AddItem(item);
            return Ok();
        }

        [HttpPut("{itemId}")]
        public IActionResult UpdateItem(Guid itemId, [FromBody] UpdateItemRequestBody item)
        {
            _itemService.UpdateItem(itemId, item);
            return Ok();
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(Guid itemId)
        {
            _itemService.DeleteItem(itemId);
            return Ok();
        }

        [HttpPost("{itemId}/take")]
        public IActionResult TakeItem(Guid itemId)
        {
            _itemService.TakeItem(itemId);
            return Ok();
        }

        [HttpPost("{itemId}/move/{newPlaceId}")]
        public IActionResult MoveItem(Guid itemId, Guid newPlaceId)
        {
            _itemService.MoveItem(itemId, newPlaceId);
            return Ok();
        }
    }
}