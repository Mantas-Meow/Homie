using Homie.API.DTOs.Recipes;

namespace Homie.API.Services.Interfaces
{
    public interface IRecipesService
    {
        
        public Task<List<RecipesResponseBody>> GetAllRecipes();
        public Task<RecipesResponseBody?> GetRecipeById(Guid recipeId);
        public Task AddRecipe(CreateRecipesRequestBody recipe);
        public Task UpdateRecipe(Guid recipeId, UpdateRecipesRequestBody recipe);
        public Task DeleteRecipe(Guid recipeId);
    }
}
