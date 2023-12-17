using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IToDoListItemsRepository
    {
        ToDoListItem CreateToDoListItem(ToDoListItem toDoListItemToCreate);
        void DeleteToDoListItem(ToDoListItem toDoListItemToDelete);

        ToDoListItem GetToDoListItemById(Guid id);

        List<ToDoListItem> GetAllToDoListItems();

        ToDoListItem UpdateToDoListItem(ToDoListItem toDoListItemToUpdate);

        List<ToDoListItem> GetToDoListItemsByDate(DateTime startDate, DateTime? endDate);
    }
}
