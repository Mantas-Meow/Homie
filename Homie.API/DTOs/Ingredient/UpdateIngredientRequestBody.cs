namespace Homie.API.DTOs.Ingredient
{
    public class UpdateIngredientRequestBody
    {
        public string FoodName { get; set; }
        public string? Description { get; set; }
        public float? Calories { get; set; }
        public float? Carbs { get; set; }
        public float? Fat { get; set; }
        public float? Protein { get; set; }
        public float? ServingAmount { get; set; }
        public string? ServingDescription { get; set; }
        public float? GramsPerServing { get; set; }

        public UpdateIngredientRequestBody(string foodName, string? description, float? calories, float? carbs, float? fat, float? protein, float? servingAmount, string? servingDescription, float? gramsPerServing)
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
