using Homie.API.DTOs.Ingredient;

namespace Homie.API.Services.Interfaces
{
    public interface IIngredientService
    {
        public Task<List<IngredientResponseBody>> GetAllIngredients();
        public Task<IngredientResponseBody?> GetIngredientById(Guid ingredientId);
        public Task AddIngredient(CreateIngredientRequestBody ingredient);
        public Task UpdateIngredient(Guid ingredientId, UpdateIngredientRequestBody ingredient);
        public Task DeleteIngredient(Guid ingredientId);
    }
}
