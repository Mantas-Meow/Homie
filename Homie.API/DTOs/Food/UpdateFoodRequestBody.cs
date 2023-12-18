namespace Homie.API.DTOs.Food
{
    public class UpdateFoodRequestBody
    {
        public string FoodName { get; set; }
        public string? Description { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? IngredientId { get; set; }
        public double? IngredientAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        public UpdateFoodRequestBody(string foodName, string? description, Guid? placeId, Guid? ingredientId, double? ingredientAmount, DateTime? lastUpdated, DateTime? expirationDate)
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
