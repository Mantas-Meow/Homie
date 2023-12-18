namespace Homie.API.DTOs.Ingredient
{
    public class IngredientResponseBody
    {
        public Guid Id { get; set; }
        public string IngredientName { get; set; }
        public string? Description { get; set; }
        public double? Calories { get; set; }
        public double? Carbs { get; set; }
        public double? Fat { get; set; }
        public double? Protein { get; set; }
        public double? ServingAmount { get; set; }
        public string? ServingDescription { get; set; }
        public double? GramsPerServing { get; set; }

        public IngredientResponseBody(Guid id, string ingredientName, string? description, double? calories, double? carbs, double? fat, double? protein, double? servingAmount, string? servingDescription, double? gramsPerServing)
        {
            Id = id;
            IngredientName = ingredientName;
            Description = description;
            Calories = calories;
            Carbs = carbs;
            Fat = fat;
            Protein = protein;
            ServingAmount = servingAmount;
            ServingDescription = servingDescription;
            GramsPerServing = gramsPerServing;
        }
    }
}
