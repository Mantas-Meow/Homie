using Homie.API.Models;
using Homie.API.Repositories.Interfaces;

namespace Homie.API.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly HomieDbContext _context;

        public ShoppingListRepository(HomieDbContext context)
        {
            _context = context;
        }

        public ShoppingListItem CreateShoppingListItem(ShoppingListItem shoppingListItemToCreate)
        {
            _context.shoppingListItems.Add(shoppingListItemToCreate);
            _context.SaveChanges();
            return shoppingListItemToCreate;
        }

        public void DeleteShoppingListItem(ShoppingListItem shoppingListItemToDelete)
        {
            _context.shoppingListItems.Remove(shoppingListItemToDelete);
            _context.SaveChanges();
        }

        public List<ShoppingListItem> GetAllShoppingListItems()
        {
            return _context.shoppingListItems.OrderBy(x => x.Name).ToList();
        }

        public List<ShoppingListItem> GetCurrentShoppingList()
        {
            return _context.shoppingListItems.Where(x => x.IsBought == false).OrderBy(x => x.Name).ToList();
        }

        public ShoppingListItem GetShoppingListItemById(Guid id)
        {
            return _context.shoppingListItems.FirstOrDefault(x => x.Id == id);
        }

        public ShoppingListItem UpdateShoppingListItem(ShoppingListItem shoppingListItemToUpdate)
        {
            _context.shoppingListItems.Update(shoppingListItemToUpdate);
            _context.SaveChanges();
            return shoppingListItemToUpdate;
        }
    }
}
