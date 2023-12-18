using Homie.API.Models;
using Homie.API.Repositories.Interfaces;

namespace Homie.API.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly HomieDbContext _homieDbContext;

        public RecipesRepository(HomieDbContext homieDbContext)
        {
            _homieDbContext = homieDbContext;
        }

        public List<Recipes> GetAllRecipes()
        {
            return _homieDbContext.Recipes.OrderBy(x => x.RecipeTitle).ToList();
        }

        public List<RecipeIngredient> GetAllIngredientsByRecipeId(Guid recipeId)
        {
            return _homieDbContext.RecipeIngredient.Where(x => x.RecipesId.Equals(recipeId)).OrderBy(x => x.IngredientId).ToList();
        }

        public async void Add(Recipes recipe)
        {
            _homieDbContext.Recipes.Add(recipe);
            _homieDbContext.SaveChanges();
        }

        public void Update(Recipes recipe)
        {
            _homieDbContext.Recipes.Update(recipe);
            _homieDbContext.SaveChanges();
        }

        public void Delete(Guid recipeId)
        {
            var recipeToRemove = GetById(recipeId);
            if (recipeToRemove != null)
            {
                _homieDbContext.Recipes.Remove(recipeToRemove);
                _homieDbContext.SaveChanges();
            }
        }

        public Recipes? GetById(Guid? recipeId)
        {
            return _homieDbContext.Recipes.Find(recipeId);
        }
    }
}