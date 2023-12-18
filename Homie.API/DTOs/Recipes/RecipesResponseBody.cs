using Homie.API.Models;

namespace Homie.API.DTOs.Recipes
{
    public class RecipesResponseBody
    {
        public Guid Id { get; set; }
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
        public List<RecipeIngredients> RecipeIngredients { get; set; }
    }

    public class RecipeIngredients
    {
        public string FoodName { get; set; }
        public string? Description { get; set; }
        public double? Calories { get; set; }
        public double? Carbs { get; set; }
        public double? Fat { get; set; }
        public double? Protein { get; set; }
        public double? ServingAmount { get; set; }
        public string? ServingDescription { get; set; }
        public double? GramsPerServing { get; set; }
        public double Amount { get; set; }
    }
}
