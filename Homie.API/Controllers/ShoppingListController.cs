using Homie.API.DTOs.ShoppingList;
using Homie.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homie.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingListItem(CreateShoppingListItemRequestBody shoppingListItem)
        {
            var createdShoppingListItem = await _shoppingListService.CreateShoppingListItem(shoppingListItem);
            return Ok(createdShoppingListItem);
        }

        [HttpGet]
        [Route("/AllShoppingListItems")]
        public async Task<IActionResult> GetAllShoppingListItems()
        {
            var shoppingList = await _shoppingListService.GetAllShoppingListItems();
            return Ok(shoppingList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetShoppingListItemById(Guid id)
        {
            var shoppingListItem = await _shoppingListService.GetShoppingListItemById(id);
            return Ok(shoppingListItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentShoppingList()
        {
            var shoppingList = await _shoppingListService.GetCurrentShoppingList();
            return Ok(shoppingList);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateShoppingListItem(Guid id, UpdateShoppingListItemRequestBody newShoppingListItem)
        {
            var updatedShoppingListItem = await _shoppingListService.UpdateShoppingListItem(id, newShoppingListItem);
            return Ok(updatedShoppingListItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteShoppingListItem(Guid id)
        {
            await _shoppingListService.DeleteShoppingListItem(id);
            return Ok();
        }
    }
}

