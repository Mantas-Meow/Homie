using Homie.API.Models;

namespace Homie.API.DTOs.Chores
{
    public class CreateChoreRequestBody
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Frequency Frequency { get; set; }
    }
}
