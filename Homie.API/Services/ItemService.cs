using Homie.API.Models;
using Homie.API.Services.Interfaces;
using Homie.API.Repositories.Interfaces;
using Homie.API.DTOs.Item;
using Homie.API.DTOs.Place;

namespace Homie.API.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPlaceRepository _placeRepository;

        public ItemService(IItemRepository itemRepository, IPlaceRepository placeRepository)
        {
            _itemRepository = itemRepository;
            _placeRepository = placeRepository;
        }

        public async Task<List<ItemResponseBody>> GetItems()
        {
            var repoItems = _itemRepository.GetItems();
            var items = new List<ItemResponseBody>();

            foreach (var item in repoItems)
            {
                var place = _placeRepository.GetById(item.PlaceId);
                if (place == null)
                {
                    items.Add(new ItemResponseBody(item.Id, item.ItemName, item.Description, null, item.LastUpdated, item.IsTaken));
                } else
                {
                    items.Add(new ItemResponseBody(item.Id, item.ItemName, item.Description, new PlaceResponseBody(place.Id, place.PlaceName, place.Description, place.Room, place.Furniture, place.LastUpdated), item.LastUpdated, item.IsTaken));
                }
                
            }
            return items;
        }

        public async Task<ItemResponseBody?> GetItemById(Guid itemId)
        {
            var item = _itemRepository.GetById(itemId);
            if (item == null)
            {
                return null;
            }

            var place = _placeRepository.GetById(item.PlaceId);
            
            if (place == null)
            {
                return new ItemResponseBody(item.Id, item.ItemName, item.Description, null, item.LastUpdated, item.IsTaken);
            }

            return new ItemResponseBody(item.Id, item.ItemName, item.Description, new PlaceResponseBody(place.Id, place.PlaceName, place.Description, place.Room, place.Furniture, place.LastUpdated), item.LastUpdated, item.IsTaken);
            
        }

        public async Task AddItem(CreateItemRequestBody item)
        {
            _itemRepository.Add(new Item(item.ItemName, item.Description, item.PlaceId, item.LastUpdated, item.IsTaken));
        }

        public async Task UpdateItem(Guid itemId, UpdateItemRequestBody item)
        {
            var existingItem = _itemRepository.GetById(itemId);
            if (existingItem != null)
            {
                existingItem.ItemName = item.ItemName;
                existingItem.Description = item.Description;
                existingItem.PlaceId = item.PlaceId;
                existingItem.LastUpdated = new DateTime();
                existingItem.IsTaken = item.IsTaken;

                _itemRepository.Update(existingItem);
            }
        }

        public async Task DeleteItem(Guid itemId)
        {
            _itemRepository.Delete(itemId);
        }

        public async Task TakeItem(Guid itemId)
        {
            var existingItem = _itemRepository.GetById(itemId);
            if (existingItem != null)
            {
                existingItem.IsTaken = !existingItem.IsTaken;
                existingItem.LastUpdated = new DateTime();
                _itemRepository.Update(existingItem);
            }
        }

        public async Task MoveItem(Guid itemId, Guid newPlaceId)
        {
            var existingItem = _itemRepository.GetById(itemId);
            if (existingItem != null)
            {
                existingItem.PlaceId = newPlaceId;
                existingItem.LastUpdated = new DateTime();
                _itemRepository.Update(existingItem);
            }
        }
    }
}