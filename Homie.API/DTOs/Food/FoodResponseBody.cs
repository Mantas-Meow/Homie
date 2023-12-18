namespace Homie.API.DTOs.Food
{
    public class FoodResponseBody
    {
        public Guid Id { get; set; }
        public string FoodName { get; set; }
        public string? Description { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? IngredientId { get; set; }
        public double? IngredientAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
