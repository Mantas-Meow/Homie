using Homie.API.DTOs.ShoppingList;
using Homie.API.DTOs.ToDoList;
using Homie.API.Models;
using Homie.API.Repositories;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public Task<CreateShoppingListItemResponseBody> CreateShoppingListItem(CreateShoppingListItemRequestBody shoppingListItem)
        {
            var shoppingListItemToCreate = new ShoppingListItem()
            {
                Id = Guid.NewGuid(),
                Name = shoppingListItem.Name,
                Amount = shoppingListItem.Amount,
                IsBought = false,
            };

            var result = _shoppingListRepository.CreateShoppingListItem(shoppingListItemToCreate);

            var createdShoppingListItem = new CreateShoppingListItemResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Amount = result.Amount,
                IsBought = result.IsBought,
            };

            return Task.FromResult(createdShoppingListItem);
        }

        public Task DeleteShoppingListItem(Guid id)
        {
            var shoppingListItem = _shoppingListRepository.GetShoppingListItemById(id);

            if (shoppingListItem != null)
            {
                _shoppingListRepository.DeleteShoppingListItem(shoppingListItem);
                return Task.CompletedTask;
            }
            else return null;
        }

        public Task<List<GetShoppingListItemResponseBody>> GetAllShoppingListItems()
        {
            var result = _shoppingListRepository.GetAllShoppingListItems();

            var shoppingListItems = new List<GetShoppingListItemResponseBody>();
            for (int i = 0; i < result.Count(); i++)
            {
                var shoppingListItem = new GetShoppingListItemResponseBody()
                {
                    Id = result[i].Id,
                    Name = result[i].Name,
                    Amount = result[i].Amount,
                    IsBought = result[i].IsBought,
                };

                shoppingListItems.Add(shoppingListItem);
            }

            return Task.FromResult(shoppingListItems);
        }

        public Task<List<GetShoppingListItemResponseBody>> GetCurrentShoppingList()
        {
            var result = _shoppingListRepository.GetCurrentShoppingList();

            var shoppingListItems = new List<GetShoppingListItemResponseBody>();
            for (int i = 0; i < result.Count(); i++)
            {
                var shoppingListItem = new GetShoppingListItemResponseBody()
                {
                    Id = result[i].Id,
                    Name = result[i].Name,
                    Amount = result[i].Amount,
                    IsBought = result[i].IsBought,
                };

                shoppingListItems.Add(shoppingListItem);
            }

            return Task.FromResult(shoppingListItems);
        }

        public Task<GetShoppingListItemResponseBody> GetShoppingListItemById(Guid id)
        {
            var result = _shoppingListRepository.GetShoppingListItemById(id);

            if (result == null)
            {
                return Task.FromResult(new GetShoppingListItemResponseBody());
            }

            var shoppingListItem = new GetShoppingListItemResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Amount = result.Amount,
                IsBought = result.IsBought,
            };

            return Task.FromResult(shoppingListItem);
        }

        public Task<UpdateShoppingListItemResponseBody> UpdateShoppingListItem(Guid id, UpdateShoppingListItemRequestBody newShoppingListItem)
        {
            var shoppingListItemToUpdate = new ShoppingListItem()
            {
                Id = id,
                Name = newShoppingListItem.Name,
                Amount = newShoppingListItem.Amount,
                IsBought = newShoppingListItem.IsBought,
            };

            var result = _shoppingListRepository.UpdateShoppingListItem(shoppingListItemToUpdate);

            var updatedshoppingListItem = new UpdateShoppingListItemResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Amount = result.Amount,
                IsBought = result.IsBought,
            };

            return Task.FromResult(updatedshoppingListItem);
        }
    }
}
