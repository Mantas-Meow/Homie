using Homie.API.DTOs.Ingredient;
using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<List<IngredientResponseBody>> GetAllIngredients()
        {
            var repoFood = _ingredientRepository.GetAllIngredients();
            var allIngredients = new List<IngredientResponseBody>();

            foreach (var food in repoFood)
            {
                allIngredients.Add(new IngredientResponseBody(food.Id, food.FoodName, food.Description, food.Calories, food.Carbs, food.Fat, food.Protein, food.ServingAmount, food.ServingDescription, food.GramsPerServing));
            }
            return allIngredients;
        }

        public async Task<IngredientResponseBody?> GetIngredientById(Guid foodId)
        {
            var ingredient = _ingredientRepository.GetById(foodId);
            if (ingredient == null)
            {
                return null;
            }
            return new IngredientResponseBody(ingredient.Id, ingredient.FoodName, ingredient.Description, ingredient.Calories, ingredient.Carbs, ingredient.Fat, ingredient.Protein, ingredient.ServingAmount, ingredient.ServingDescription, ingredient.GramsPerServing);
        }

        public async Task AddIngredient(CreateIngredientRequestBody ingredient)
        {
            _ingredientRepository.Add(new Ingredient(ingredient.FoodName, ingredient.Description, ingredient.Calories, ingredient.Carbs, ingredient.Fat, ingredient.Protein, ingredient.ServingAmount, ingredient.ServingDescription, ingredient.GramsPerServing));
        }

        public async Task UpdateIngredient(Guid ingredientId, UpdateIngredientRequestBody ingredient)
        {
            var existingItem = _ingredientRepository.GetById(ingredientId);
            if (existingItem != null)
            {
                existingItem.FoodName = ingredient.FoodName;
                existingItem.Description = ingredient.Description;
                existingItem.Calories = ingredient.Calories;
                existingItem.Carbs = ingredient.Carbs;
                existingItem.Fat = ingredient.Fat;
                existingItem.Protein = ingredient.Protein;
                existingItem.ServingAmount = ingredient.ServingAmount;
                existingItem.ServingDescription = ingredient.ServingDescription;
                existingItem.GramsPerServing = ingredient.GramsPerServing;

                _ingredientRepository.Update(existingItem);
            }
        }

        public async Task DeleteIngredient(Guid foodId)
        {
            _ingredientRepository.Delete(foodId);
        }
    }
}
