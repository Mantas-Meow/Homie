using Homie.API.DTOs.Chores;
using Homie.API.Models;

namespace Homie.API.Services.Interfaces
{
    public interface IChoresService
    {
        Task<CreateChoreResponseBody> CreateChore(CreateChoreRequestBody chore);
        Task<List<GetChoresResponseBody>> GetAllChores();
        Task<GetChoresResponseBody> GetChore(Guid id);
        Task<UpdateChoreResponseBody> UpdateChore(Guid id, UpdateChoreRequestBody newChore);
        Task DeleteChore(Guid id);
    }
}
