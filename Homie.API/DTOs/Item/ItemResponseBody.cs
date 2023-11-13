using Homie.API.DTOs.Place;

namespace Homie.API.DTOs.Item
{
    public class ItemResponseBody
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string? Description { get; set; }
        public PlaceResponseBody? Place { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsTaken { get; set; }
    
        public ItemResponseBody(Guid id, string itemName, string? description, PlaceResponseBody? place, DateTime? lastUpdated, bool? isTaken)
        {
            Id = id;
            ItemName = itemName;
            Description = description;
            Place = place;
            LastUpdated = lastUpdated;
            IsTaken = isTaken;
        }
    }
}
