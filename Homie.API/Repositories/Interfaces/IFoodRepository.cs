using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        public List<Food> GetAllFood();
        public void Add(Food food);
        public void Update(Food food);
        public void Delete(Guid foodId);
        public Food? GetById(Guid? foodId);
    }
}
