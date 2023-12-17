using Homie.API.DTOs.Item;

namespace Homie.API.Services.Interfaces
{
    public interface IItemService
    {
        public Task<List<ItemResponseBody>> GetItems();
        public Task AddItem(CreateItemRequestBody item);
        public Task<ItemResponseBody?> GetItemById(Guid itemId);
        public Task UpdateItem(Guid itemId, UpdateItemRequestBody item);
        public Task DeleteItem(Guid itemId);
        public Task TakeItem(Guid itemId);
        public Task MoveItem(Guid itemId, Guid newPlaceId);
    }
}
