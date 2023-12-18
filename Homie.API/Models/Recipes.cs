using System.ComponentModel.DataAnnotations;

namespace Homie.API.Models
{
    public class Recipes
    {
        [Key]
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
        public List<RecipeIngredient> RecipeIngredients { get; set; } 
    }



    public class RecipeIngredient
    {
        [Key]
        public Guid RecipesId { get; set; }
        public virtual Recipes Recipes { get; set; }
        public Guid IngredientId { get; set; }
        public double Amount { get; set; }
    }

    public enum RecipeCategory
    {
        Appetizer, Salad, Drink, Sandwitch, Pasta, Soup, Meat, Vegan, Sweet, Other
    }

    public enum Dish
    {
        Main, Side
    }

    [Flags]
    public enum RecipeTypes
    {
        Breakfast, Lunch, Dinner, Snack, Dessert
    }
}
