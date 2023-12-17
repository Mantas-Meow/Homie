using Homie.API.DTOs.Food;
using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<List<FoodResponseBody>> GetAllFoodItems()
        {
            var repoFood = _foodRepository.GetAllFood();
            var allFood = new List<FoodResponseBody>();

            foreach (var food in repoFood)
            {
                allFood.Add(new FoodResponseBody()
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    Description = food.Description,
                    PlaceId = food.PlaceId,
                    IngredientId = food.IngredientId,
                    IngredientAmount = food.IngredientAmount,
                    ExpirationDate = food.ExpirationDate,
                    LastUpdated = new DateTime()
                });
            }
            return allFood;
        }

        public async Task<FoodResponseBody?> GetFoodItemById(Guid foodId)
        {
            var food = _foodRepository.GetById(foodId);
            if (food == null)
            {
                return null;
            }
            return new FoodResponseBody()
            {
                Id = food.Id,
                FoodName = food.FoodName,
                Description = food.Description,
                PlaceId = food.PlaceId,
                IngredientId = food.IngredientId,
                IngredientAmount = food.IngredientAmount,
                ExpirationDate = food.ExpirationDate,
                LastUpdated = new DateTime()
            };
        }

        public async Task AddFoodItem(CreateFoodRequestBody food)
        {
            _foodRepository.Add(new Food()
            {
                FoodName = food.FoodName,
                Description = food.Description,
                PlaceId = food.PlaceId,
                IngredientId = food.IngredientId,
                IngredientAmount = food.IngredientAmount,
                ExpirationDate = food.ExpirationDate,
                LastUpdated = new DateTime()
            });
        }

        public async Task UpdateFoodItem(Guid foodId, UpdateFoodRequestBody food)
        {
            var existingItem = _foodRepository.GetById(foodId);
            if (existingItem != null)
            {
                existingItem.FoodName = food.FoodName;
                existingItem.Description = food.Description;
                existingItem.PlaceId = food.PlaceId;
                existingItem.IngredientId = food.IngredientId;
                existingItem.IngredientAmount = food.IngredientAmount;
                existingItem.ExpirationDate = food.ExpirationDate;
                existingItem.ExpirationDate = food.ExpirationDate;
                existingItem.LastUpdated = new DateTime();

                _foodRepository.Update(existingItem);
            }
        }

        public async Task DeleteFoodItem(Guid foodId)
        {
            _foodRepository.Delete(foodId);
        }
    }
}
