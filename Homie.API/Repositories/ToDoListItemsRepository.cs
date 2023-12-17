using Homie.API.Models;
using Homie.API.Repositories.Interfaces;

namespace Homie.API.Repositories
{
    public class ToDoListItemsRepository : IToDoListItemsRepository
    {
        private readonly HomieDbContext _context;

        public ToDoListItemsRepository(HomieDbContext context)
        {
            _context = context;
        }
        public ToDoListItem CreateToDoListItem(ToDoListItem toDoListItemToCreate)
        {
            _context.ToDoListItems.Add(toDoListItemToCreate);
            _context.SaveChanges();
            return toDoListItemToCreate;
        }

        public void DeleteToDoListItem(ToDoListItem toDoListItemToDelete)
        {
            _context.ToDoListItems.Remove(toDoListItemToDelete);
            _context.SaveChanges();
        }

        public List<ToDoListItem> GetAllToDoListItems()
        {
            return _context.ToDoListItems.OrderBy(x => x.DateToDo).ToList();
        }

        public ToDoListItem GetToDoListItemById(Guid id)
        {
            return _context.ToDoListItems.FirstOrDefault(x => x.Id == id);
        }

        public List<ToDoListItem> GetToDoListItemsByDate(DateTime startDate, DateTime? endDate)
        {
            return _context.ToDoListItems.Where(x => x.DateToDo >= startDate && x.DateToDo <= endDate)
                                         .OrderBy(x => x.DateToDo)
                                         .ToList();
        }

        public ToDoListItem UpdateToDoListItem(ToDoListItem toDoListItemToUpdate)
        {
            _context.ToDoListItems.Update(toDoListItemToUpdate);
            _context.SaveChanges();
            return toDoListItemToUpdate;
        }
    }
}
