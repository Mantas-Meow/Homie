namespace Homie.API.DTOs.Place
{
    public class CreatePlaceRequestBody
    {
        public string PlaceName { get; set; }
        public string? Description { get; set; }
        public string? Room { get; set; }
        public string? Furniture { get; set; }
        public DateTime? LastUpdated { get; set; }

        public CreatePlaceRequestBody(string placeName, string? description, string? room, string? furniture, DateTime? lastUpdated)
        {
            PlaceName = placeName;
            Description = description;
            LastUpdated = lastUpdated;
            Furniture = furniture;
            Room = room;
        }
    }
}
