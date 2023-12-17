namespace Homie.API.DTOs.Food
{
    public class CreateFoodRequestBody
    {
        public string FoodName { get; set; }
        public string? Description { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? IngredientId { get; set; }
        public float? IngredientAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        public CreateFoodRequestBody(string foodName, string? description, Guid? placeId, Guid? ingredientId, float? ingredientAmount, DateTime? lastUpdated, DateTime? expirationDate)
        {
            FoodName = foodName;
            Description = description;
            PlaceId = placeId;
            LastUpdated = lastUpdated;
            IngredientId = ingredientId;
            IngredientAmount = ingredientAmount;
            ExpirationDate = expirationDate;
        }
    }
}
