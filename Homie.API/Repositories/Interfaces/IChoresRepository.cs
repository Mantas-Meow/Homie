using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IChoresRepository
    {
        Chore CreateChore(Chore choreToCreate);
        void DeleteChore(Chore choreToDelete);

        Chore GetChoreById(Guid id);

        List<Chore> GetAllChores();

        Chore UpdateChore(Chore choreToUpdate);
    }
}
