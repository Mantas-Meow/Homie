using Homie.API.DTOs.Chores;
using Homie.API.DTOs.ToDoList;

namespace Homie.API.Services.Interfaces
{
    public interface IToDoListItemsService
    {
        Task<CreateToDoListItemResponseBody> CreateToDoListItem(CreateToDoListItemRequestBody toDoItem);
        Task<List<GetToDoListItemResponseBody>> GetAllToDoListItems();
        Task<GetToDoListItemResponseBody> GetToDoListItem(Guid id);
        Task<List<GetToDoListItemResponseBody>> GetAllToDoListItemsByDate(DateTime startDate, DateTime endTime);
        Task<UpdateToDoListItemResponseBody> UpdateToDoListItem(Guid id, UpdateToDoListItemRequestBody newToDoListItem);
        Task DeleteToDoListItem(Guid id);
    }
}
