using Homie.API.DTOs.Food;

namespace Homie.API.Services.Interfaces
{
    public interface IFoodService
    {
        public Task<List<FoodResponseBody>> GetAllFoodItems();
        public Task<FoodResponseBody?> GetFoodItemById(Guid foodId);
        public Task AddFoodItem(CreateFoodRequestBody food);
        public Task UpdateFoodItem(Guid foodId, UpdateFoodRequestBody food);
        public Task DeleteFoodItem(Guid foodId);
    }
}
