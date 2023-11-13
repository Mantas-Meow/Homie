namespace Homie.API.DTOs.Item
{
    public class UpdateItemRequestBody
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string? Description { get; set; }
        public Guid? PlaceId { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsTaken { get; set; }
    
        public UpdateItemRequestBody(string itemName, string? description, Guid? placeId, DateTime? lastUpdated, bool? isTaken)
        {
            Id = new Guid();
            ItemName = itemName;
            Description = description;
            PlaceId = placeId;
            LastUpdated = lastUpdated;
            IsTaken = isTaken;
        }
    }
}
