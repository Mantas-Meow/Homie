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

        public List<ItemResponseBody> GetItems()
        {
            var repoItems = _itemRepository.GetItems();
            var items = new List<ItemResponseBody>();

            foreach (var item in repoItems)
            {
                var place = _placeRepository.GetById(item.PlaceId);
                var placeResponseBody = new PlaceResponseBody();
                if (place != null)
                {
                    placeResponseBody.Id = place.Id;
                    placeResponseBody.PlaceName = place.PlaceName;
                    placeResponseBody.Description = place.Description;
                    placeResponseBody.Room = place.Room;
                    placeResponseBody.Furniture = place.Furniture;
                    placeResponseBody.LastUpdated = place.LastUpdated;
                }
                items.Add(new ItemResponseBody(item.Id, item.ItemName, item.Description, placeResponseBody, item.LastUpdated, item.IsTaken));
            }
            return items;
        }

        public ItemResponseBody? GetItemById(Guid itemId)
        {
            var item = _itemRepository.GetById(itemId);
            if (item == null)
            {
                return null;
            }

            var place = _placeRepository.GetById(item.PlaceId);
            var placeResponseBody = new PlaceResponseBody();
            if (place != null)
            {
                placeResponseBody.Id = place.Id;
                placeResponseBody.PlaceName = place.PlaceName;
                placeResponseBody.Description = place.Description;
                placeResponseBody.Room = place.Room;
                placeResponseBody.Furniture = place.Furniture;
                placeResponseBody.LastUpdated = place.LastUpdated;
            }
            return new ItemResponseBody(item.Id, item.ItemName, item.Description, placeResponseBody, item.LastUpdated, item.IsTaken);
        }

        public void AddItem(CreateItemRequestBody item)
        {
            _itemRepository.Add(new Item(item.ItemName, item.Description, item.PlaceId, item.LastUpdated, item.IsTaken));
        }

        public void UpdateItem(Guid itemId, UpdateItemRequestBody item)
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

        public void DeleteItem(Guid itemId)
        {
            _itemRepository.Delete(itemId);
        }

        public void TakeItem(Guid itemId)
        {
            var existingItem = _itemRepository.GetById(itemId);
            if (existingItem != null)
            {
                existingItem.IsTaken = !existingItem.IsTaken;
                existingItem.LastUpdated = new DateTime();
                _itemRepository.Update(existingItem);
            }
        }

        public void MoveItem(Guid itemId, Guid newPlaceId)
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