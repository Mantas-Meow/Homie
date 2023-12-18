using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IRecipesRepository
    {
        public List<Recipes> GetAllRecipes();
        public void Add(Recipes food);
        public void Update(Recipes food);
        public void Delete(Guid foodId);
        public Recipes? GetById(Guid? foodId);
        public List<RecipeIngredient> GetAllIngredientsByRecipeId(Guid recipeId);
    }
}
