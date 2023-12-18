using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IItemRepository
    {
        public List<Item> GetItems();
        public void Add(Item item);
        public void Update(Item item);
        public void Delete(Guid itemId);
        public Item? GetById(Guid itemId);
        public List<Item> GetByPlaceId(Guid placeId);
    }
}
