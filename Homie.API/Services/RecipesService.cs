using Homie.API.DTOs.Recipes;
using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public RecipesService(IRecipesRepository recipesRepository, IIngredientRepository ingredientRepository)
        {
            _recipesRepository = recipesRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<List<RecipesResponseBody>> GetAllRecipes()
        {
            var repoRecipes = _recipesRepository.GetAllRecipes();
            var allRecipes = new List<RecipesResponseBody>();

            foreach (var recipe in repoRecipes)
            {
                var newRecipe = new RecipesResponseBody()
                {
                    Id = recipe.Id,
                    RecipeTitle = recipe.RecipeTitle,
                    PrepTime = recipe.PrepTime,
                    CookTime = recipe.CookTime,
                    Portions = recipe.Portions,
                    Category = recipe.Category,
                    Dish = recipe.Dish,
                    RecipeTypes = recipe.RecipeTypes,
                    TotalCalories = recipe.TotalCalories,
                    TotalCarbs = recipe.TotalCarbs,
                    TotalFat = recipe.TotalFat,
                    TotalProtein = recipe.TotalProtein,
                    Directions = recipe.Directions,
                    RecipeIngredients = new List<RecipeIngredients>()
                };
                var ingredients = _recipesRepository.GetAllIngredientsByRecipeId(newRecipe.Id);
                if (ingredients != null)
                {
                    foreach (var recipeIngrediant in ingredients)
                    {
                        var ingrediant = _ingredientRepository.GetById(recipeIngrediant.IngredientId);
                        newRecipe.TotalCalories = newRecipe.TotalCalories + ingrediant.Calories;
                        newRecipe.TotalCarbs = newRecipe.TotalCarbs + ingrediant.Carbs;
                        newRecipe.TotalFat = newRecipe.TotalFat + ingrediant.Fat;
                        newRecipe.TotalProtein = newRecipe.TotalProtein + ingrediant.Protein;
                        newRecipe.RecipeIngredients.Add(new RecipeIngredients
                        {
                            FoodName = ingrediant.FoodName,
                            Description = ingrediant.Description,
                            Calories = ingrediant.Calories,
                            Carbs = ingrediant.Carbs,
                            Fat = ingrediant.Fat,
                            Protein = ingrediant.Protein,
                            ServingAmount = ingrediant.ServingAmount,
                            ServingDescription = ingrediant.ServingDescription,
                            GramsPerServing = ingrediant.GramsPerServing,
                            Amount = recipeIngrediant.Amount
                        });
                    }
                }
                allRecipes.Add(newRecipe);
            }
            return allRecipes;
        }

        public async Task<RecipesResponseBody?> GetRecipeById(Guid recipeId)
        {
            var recipe = _recipesRepository.GetById(recipeId);
            if (recipe == null)
            {
                return null;
            }

            var newRecipe = new RecipesResponseBody()
            {
                Id = recipe.Id,
                RecipeTitle = recipe.RecipeTitle,
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
                Portions = recipe.Portions,
                Category = recipe.Category,
                Dish = recipe.Dish,
                RecipeTypes = recipe.RecipeTypes,
                TotalCalories = recipe.TotalCalories,
                TotalCarbs = recipe.TotalCarbs,
                TotalFat = recipe.TotalFat,
                TotalProtein = recipe.TotalProtein,
                Directions = recipe.Directions,
                RecipeIngredients = new List<RecipeIngredients>()
            };
            var ingredients = _recipesRepository.GetAllIngredientsByRecipeId(newRecipe.Id);
            if (ingredients != null)
            {
                foreach (var recipeIngrediant in ingredients)
                {
                    var ingrediant = _ingredientRepository.GetById(recipeIngrediant.IngredientId);
                    newRecipe.TotalCalories = newRecipe.TotalCalories + ingrediant.Calories;
                    newRecipe.TotalCarbs = newRecipe.TotalCarbs + ingrediant.Carbs;
                    newRecipe.TotalFat = newRecipe.TotalFat + ingrediant.Fat;
                    newRecipe.TotalProtein = newRecipe.TotalProtein + ingrediant.Protein;
                    newRecipe.RecipeIngredients.Add(new RecipeIngredients
                    {
                        FoodName = ingrediant.FoodName,
                        Description = ingrediant.Description,
                        Calories = ingrediant.Calories,
                        Carbs = ingrediant.Carbs,
                        Fat = ingrediant.Fat,
                        Protein = ingrediant.Protein,
                        ServingAmount = ingrediant.ServingAmount,
                        ServingDescription = ingrediant.ServingDescription,
                        GramsPerServing = ingrediant.GramsPerServing,
                        Amount = recipeIngrediant.Amount
                    });
                }
            }

            return newRecipe;
        }

        public async Task AddRecipe(CreateRecipesRequestBody recipe)
        {
            var recipeId = Guid.NewGuid();
            var newRecipe = new Recipes()
            {
                Id = recipeId,
                RecipeTitle = recipe.RecipeTitle,
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
                Portions = recipe.Portions,
                Category = recipe.Category,
                Dish = recipe.Dish,
                RecipeTypes = recipe.RecipeTypes,
                Directions = recipe.Directions,
                RecipeIngredients = recipe.RecipeIngredients
            };

            var ingredients = _recipesRepository.GetAllIngredientsByRecipeId(newRecipe.Id);
            if (ingredients != null)
            {
                foreach (var recipeIngrediant in ingredients)
                {
                    var ingrediant = _ingredientRepository.GetById(recipeIngrediant.IngredientId);
                    newRecipe.TotalCalories = newRecipe.TotalCalories + ingrediant.Calories;
                    newRecipe.TotalCarbs = newRecipe.TotalCarbs + ingrediant.Carbs;
                    newRecipe.TotalFat = newRecipe.TotalFat + ingrediant.Fat;
                    newRecipe.TotalProtein = newRecipe.TotalProtein + ingrediant.Protein;
                    newRecipe.RecipeIngredients.Add(new RecipeIngredient
                    {
                        RecipesId = recipeIngrediant.RecipesId,
                        IngredientId = recipeIngrediant.IngredientId,
                        Amount = recipeIngrediant.Amount
                    });
                }
            }

            _recipesRepository.Add(newRecipe);
        }

        public async Task UpdateRecipe(Guid recipeId, UpdateRecipesRequestBody recipe)
        {
            var existingRecipe = _recipesRepository.GetById(recipeId);
            if (existingRecipe != null)
            {
                existingRecipe.RecipeTitle = recipe.RecipeTitle;
                existingRecipe.PrepTime = recipe.PrepTime;
                existingRecipe.CookTime = recipe.CookTime;
                existingRecipe.Portions = recipe.Portions;
                existingRecipe.Category = recipe.Category;
                existingRecipe.Dish = recipe.Dish;
                existingRecipe.TotalCalories = recipe.TotalCalories;
                existingRecipe.TotalCarbs = recipe.TotalCarbs;
                existingRecipe.TotalFat = recipe.TotalFat;
                existingRecipe.TotalProtein = recipe.TotalProtein;
                existingRecipe.RecipeTypes = recipe.RecipeTypes;
                existingRecipe.Directions = recipe.Directions;
                existingRecipe.RecipeIngredients = recipe.RecipeIngredients;

                _recipesRepository.Update(existingRecipe);
            }
        }

        public async Task DeleteRecipe(Guid recipeId)
        {
            _recipesRepository.Delete(recipeId);
        }
    }
}
