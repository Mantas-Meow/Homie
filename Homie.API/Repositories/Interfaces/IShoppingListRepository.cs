using Homie.API.Migrations;
using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IShoppingListRepository
    {
        ShoppingListItem CreateShoppingListItem(ShoppingListItem shoppingListItemToCreate);
        void DeleteShoppingListItem(ShoppingListItem shoppingListItemToDelete);

        ShoppingListItem GetShoppingListItemById(Guid id);

        List<ShoppingListItem> GetAllShoppingListItems();

        ShoppingListItem UpdateShoppingListItem(ShoppingListItem shoppingListItemToUpdate);

        List<ShoppingListItem> GetCurrentShoppingList();
    }
}
