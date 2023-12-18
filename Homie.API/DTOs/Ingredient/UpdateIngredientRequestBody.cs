namespace Homie.API.DTOs.Ingredient
{
    public class UpdateIngredientRequestBody
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

        public UpdateIngredientRequestBody(string foodName, string? description, double? calories, double? carbs, double? fat, double? protein, double? servingAmount, string? servingDescription, double? gramsPerServing)
        {
            FoodName = foodName;
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
