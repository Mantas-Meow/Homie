using Homie.API.Models;

namespace Homie.API.DTOs.Chores
{
    public class GetChoresResponseBody
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class GetChoresItemResponseBody
    {
        public Guid Id { get; set; }
        public GetChoresResponseBody Chore { get; set; }
        public Boolean IsCompleted { get; set; }
    }
}
