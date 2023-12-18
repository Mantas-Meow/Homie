using Homie.API.DTOs.Place;

namespace Homie.API.DTOs.Item
{
    public class GetItemsByPlaceResponseBody
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string? Description { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsTaken { get; set; }
    }
}
