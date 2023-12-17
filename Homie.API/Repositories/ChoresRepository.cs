using Homie.API.Models;
using Homie.API.Repositories.Interfaces;

namespace Homie.API.Repositories
{
    public class ChoresRepository : IChoresRepository
    {
        private readonly HomieDbContext _context;

        public ChoresRepository(HomieDbContext context)
        {
            _context = context;
        }

        public Chore CreateChore(Chore choreToCreate)
        {
            _context.Chores.Add(choreToCreate);
            _context.SaveChanges();
            return choreToCreate;
        }

        public void DeleteChore(Chore choreToDelete)
        {
            _context.Chores.Remove(choreToDelete);
            _context.SaveChanges();
        }

        public List<Chore> GetAllChores()
        {
            return _context.Chores.OrderBy(x => x.DateCreated).ToList();
        }

        public Chore GetChoreById(Guid id)
        {
            return _context.Chores.FirstOrDefault(x => x.Id == id);
        }

        public Chore UpdateChore(Chore choreToUpdate)
        {
            _context.Chores.Update(choreToUpdate);
            _context.SaveChanges();
            return choreToUpdate;
        }
    }
}
