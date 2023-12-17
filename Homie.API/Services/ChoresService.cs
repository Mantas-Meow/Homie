using Homie.API.DTOs.Chores;
using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class ChoresService : IChoresService
    {
        private readonly IChoresRepository _choresRepository;
        private readonly IToDoListItemsRepository _toDoListItemsRepository;

        public ChoresService(IChoresRepository choresRepository, IToDoListItemsRepository toDoListItemsRepository)
        {
            _choresRepository = choresRepository;
            _toDoListItemsRepository = toDoListItemsRepository;
        }
        public async Task<CreateChoreResponseBody> CreateChore(CreateChoreRequestBody chore)
        {
            var choreToCreate = new Chore()
            {
                Id = Guid.NewGuid(),
                Name = chore.Name,
                Description = chore.Description,
                Frequency = chore.Frequency,
                DateCreated = DateTime.Now,
            };

            var result = _choresRepository.CreateChore(choreToCreate);

            var createdChore = new CreateChoreResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Frequency = result.Frequency,
                DateCreated = result.DateCreated,
            };

            var choreItems = CreateChoreItems(createdChore);

            if (choreItems != null)
                return createdChore;
            else
                return null;
        }

        public Task? DeleteChore(Guid id)
        {
            var chore = _choresRepository.GetChoreById(id);

            if (chore != null)
            {
                _choresRepository.DeleteChore(chore);
                return Task.CompletedTask;
            }
            else return null;
        }

        public Task<GetChoresResponseBody?> GetChore(Guid id)
        {
            var result = _choresRepository.GetChoreById(id);

            if (result == null)
            {
                return Task.FromResult(new GetChoresResponseBody());
            }

            var chore = new GetChoresResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Frequency = result.Frequency,
                DateCreated = result.DateCreated,
            };

            return Task.FromResult(chore);
        }

        public Task<List<GetChoresResponseBody>> GetAllChores()
        {
            var results = _choresRepository.GetAllChores();
            var chores = new List<GetChoresResponseBody>();

            foreach(Chore result in results)
            {
                var chore = new GetChoresResponseBody()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    Frequency = result.Frequency,
                    DateCreated = result.DateCreated,
                };

                chores.Add(chore);
            }

            return Task.FromResult(chores);
        }

        public Task<UpdateChoreResponseBody> UpdateChore(Guid id, UpdateChoreRequestBody newChore)
        {
            var choreToUpdate = new Chore()
            {
                Id = id,
                Name = newChore.Name,
                Description = newChore.Description,
                Frequency = newChore.Frequency,
                DateCreated = DateTime.Now,
            };

            var result = _choresRepository.UpdateChore(choreToUpdate);

            var updatedChore = new UpdateChoreResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Frequency = result.Frequency,
                DateCreated = result.DateCreated,
            };

            return Task.FromResult(updatedChore);
        }

        public List<ToDoListItem> CreateChoreItems(CreateChoreResponseBody chore)
        {
            var freq = 0;
            var date = chore.DateCreated;
            var choreItems = new List<ToDoListItem>(); ;

            switch(chore.Frequency)
            {
                case Frequency.Daily:
                    freq = 1;
                    break;
                case Frequency.Weekly:
                    freq = 7;
                    break;
                case Frequency.BiWeekly:
                    freq = 4;
                    break;
                case Frequency.Montly:
                    freq = 30;
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                var choreItem = new ToDoListItem()
                {
                    Id = Guid.NewGuid(),
                    ChoreId = chore.Id,
                    Name = chore.Name,
                    Description = chore.Description,
                    IsCompleted = false,
                    DateToDo = date.AddDays(freq)
                };

                date = date.AddDays(freq);

                _toDoListItemsRepository.CreateToDoListItem(choreItem);
                choreItems.Add(choreItem);

            }

            return choreItems;

        }
    }
}
