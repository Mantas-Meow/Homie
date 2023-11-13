namespace Homie.API.Models
{
    public class Place
    {
        public Guid Id { get; set; }
        public string PlaceName { get; set; }
        public string? Description { get; set; }
        public string? Room { get; set; }
        public string? Furniture { get; set; }
        public DateTime? LastUpdated { get; set; }

        public Place(string placeName, string? description, string? room, string? furniture, DateTime? lastUpdated)
        {
            Id = new Guid();
            PlaceName = placeName;
            Description = description;
            LastUpdated = lastUpdated;
            Furniture = furniture;
            Room = room;
        }
    }
}
