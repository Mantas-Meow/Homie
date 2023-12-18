using Homie.API.Models;

namespace Homie.API.DTOs.Recipes
{
    public class UpdateRecipesRequestBody
    {
        public string RecipeTitle { get; set; }
        public double? PrepTime { get; set; }
        public double? CookTime { get; set; }
        public double? Portions { get; set; }
        public RecipeCategory? Category { get; set; }
        public Dish? Dish { get; set; }
        public RecipeTypes? RecipeTypes { get; set; }
        public double? TotalCalories { get; set; }
        public double? TotalCarbs { get; set; }
        public double? TotalFat { get; set; }
        public double? TotalProtein { get; set; }
        public string? Directions { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
