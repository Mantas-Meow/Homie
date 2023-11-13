using Homie.API.DTOs.Item;

namespace Homie.API.Services.Interfaces
{
    public interface IItemService
    {
        public List<ItemResponseBody> GetItems();
        public void AddItem(CreateItemRequestBody item);
        public ItemResponseBody? GetItemById(Guid itemId);
        public void UpdateItem(Guid itemId, UpdateItemRequestBody item);
        public void DeleteItem(Guid itemId);
        public void TakeItem(Guid itemId);
        public void MoveItem(Guid itemId, Guid newPlaceId);
    }
}
