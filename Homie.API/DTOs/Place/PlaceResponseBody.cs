namespace Homie.API.DTOs.Place
{
    public class PlaceResponseBody
    {
        public Guid Id { get; set; }
        public string PlaceName { get; set; }
        public string? Description { get; set; }
        public string? Room { get; set; }
        public string? Furniture { get; set; }
        public DateTime? LastUpdated { get; set; }

        public PlaceResponseBody(Guid id, string placeName, string? description, string? room, string? furniture, DateTime? lastUpdated)
        {
            Id = id;
            PlaceName = placeName;
            Description = description;
            LastUpdated = lastUpdated;
            Furniture = furniture;
            Room = room;
        }

        public PlaceResponseBody()
        {
        }
    }
}
