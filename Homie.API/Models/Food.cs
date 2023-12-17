namespace Homie.API.Models
{
    public class Food
    {
        public Guid Id { get; set; }
        public string FoodName { get; set; }
        public string? Description { get; set; }
        public Guid? PlaceId { get; set; }
        public Guid? IngredientId { get; set; }
        public float? IngredientAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
