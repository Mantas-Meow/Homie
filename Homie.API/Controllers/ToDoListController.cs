using Homie.API.DTOs.ToDoList;
using Homie.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListItemsService _toDoListItemsService;

        public ToDoListController(IToDoListItemsService toDoListItemsService)
        {
            _toDoListItemsService = toDoListItemsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoListItem(CreateToDoListItemRequestBody toDoItem)
        {
            var createdToDoListItem = await _toDoListItemsService.CreateToDoListItem(toDoItem);
            return Ok(createdToDoListItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDoListItems()
        {
            var toDoList = await _toDoListItemsService.GetAllToDoListItems();
            return Ok(toDoList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetToDoListItem(Guid id)
        {
            var toDoListItem = await _toDoListItemsService.GetToDoListItem(id);
            return Ok(toDoListItem);
        }

        [HttpGet]
        [Route("{startDate}/{endDate}")]
        public async Task<IActionResult> GetAllToDoListItemsByDate(DateTime startDate, DateTime endDate)
        {
            var toDoList = await _toDoListItemsService.GetAllToDoListItemsByDate(startDate, endDate);
            return Ok(toDoList);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateToDoListItem(Guid id, UpdateToDoListItemRequestBody newToDoListItem)
        {
            var updatedToDoListItem = await _toDoListItemsService.UpdateToDoListItem(id, newToDoListItem);
            return Ok(updatedToDoListItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteToDoListItem(Guid id)
        {
            await _toDoListItemsService.DeleteToDoListItem(id);
            return Ok();
        }
    }
}
