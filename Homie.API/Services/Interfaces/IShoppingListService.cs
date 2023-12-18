using Homie.API.DTOs.ShoppingList;

namespace Homie.API.Services.Interfaces
{
    public interface IShoppingListService
    {
        Task<CreateShoppingListItemResponseBody> CreateShoppingListItem(CreateShoppingListItemRequestBody shoppingListItem);
        Task<List<GetShoppingListItemResponseBody>> GetAllShoppingListItems();
        Task<GetShoppingListItemResponseBody> GetShoppingListItemById(Guid id);
        Task<List<GetShoppingListItemResponseBody>> GetCurrentShoppingList();
        Task<UpdateShoppingListItemResponseBody> UpdateShoppingListItem(Guid id, UpdateShoppingListItemRequestBody newShoppingListItem);
        Task DeleteShoppingListItem(Guid id);
    }
}
