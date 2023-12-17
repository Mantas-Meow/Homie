using Homie.API.DTOs.Chores;
using Homie.API.DTOs.ToDoList;
using Homie.API.Models;
using Homie.API.Repositories;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class ToDoListItemsService : IToDoListItemsService
    {
        private readonly IToDoListItemsRepository _toDoListItemsRepository;

        public ToDoListItemsService(IToDoListItemsRepository toDoListItemsReposotory)
        {
            _toDoListItemsRepository = toDoListItemsReposotory;
        }

        public Task<CreateToDoListItemResponseBody> CreateToDoListItem(CreateToDoListItemRequestBody toDoItem)
        {
            var toDoListItemToCreate = new ToDoListItem()
            {
                Id = Guid.NewGuid(),
                Name = toDoItem.Name,
                Description = toDoItem.Description,
                IsCompleted = false,
                DateToDo = toDoItem.DateToDo,
            };

            var result = _toDoListItemsRepository.CreateToDoListItem(toDoListItemToCreate);

            var createdToDoListItem = new CreateToDoListItemResponseBody()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                IsCompleted = result.IsCompleted,
                DateToDo = result.DateToDo,
            };

            return Task.FromResult(createdToDoListItem);
        }

        public Task? DeleteToDoListItem(Guid id)
        {
            var toDoListItem = _toDoListItemsRepository.GetToDoListItemById(id);

            if(toDoListItem != null)
            {
                _toDoListItemsRepository.DeleteToDoListItem(toDoListItem);
                return Task.CompletedTask;
            }
            else return null;
        }

        public Task<List<GetToDoListItemResponseBody>> GetAllToDoListItems()
        {
            var result = _toDoListItemsRepository.GetAllToDoListItems();

            var toDoListItems = new List<GetToDoListItemResponseBody>();
            for (int i = 0; i < result.Count(); i++)
            {
                var toDoListItem = new GetToDoListItemResponseBody()
                {
                    Id = result[i].Id,
                    ChoreId = result[i].ChoreId,
                    Name = result[i].Name,
                    Description = result[i].Description,
                    IsCompleted = result[i].IsCompleted,
                    DateToDo = result[i].DateToDo,
                };

                toDoListItems.Add(toDoListItem);
            }

            return Task.FromResult(toDoListItems);
        }

        public Task<List<GetToDoListItemResponseBody>> GetAllToDoListItemsByDate(DateTime startDate, DateTime endDate)
        {
            var result = _toDoListItemsRepository.GetToDoListItemsByDate(startDate, endDate);

            if (result == null)
            {
                return Task.FromResult(new List<GetToDoListItemResponseBody>());
            }

            var toDoListItems = new List<GetToDoListItemResponseBody>();
            for(int i = 0; i < result.Count(); i++)
            {
                var toDoListItem = new GetToDoListItemResponseBody()
                {
                    Id = result[i].Id,
                    ChoreId = result[i].ChoreId,
                    Name = result[i].Name,
                    Description = result[i].Description,
                    IsCompleted = result[i].IsCompleted,
                    DateToDo = result[i].DateToDo,
                };

                toDoListItems.Add(toDoListItem);
            }

            return Task.FromResult(toDoListItems);
        }

        public Task<GetToDoListItemResponseBody> GetToDoListItem(Guid id)
        {
            var result = _toDoListItemsRepository.GetToDoListItemById(id);

            if (result == null)
            {
                return Task.FromResult(new GetToDoListItemResponseBody());
            }

            var toDoListItem = new GetToDoListItemResponseBody()
            {
                Id = result.Id,
                ChoreId = result.ChoreId,
                Name = result.Name,
                Description = result.Description,
                IsCompleted = result.IsCompleted,
                DateToDo = result.DateToDo,
            };

            return Task.FromResult(toDoListItem);
        }

        public Task<UpdateToDoListItemResponseBody> UpdateToDoListItem(Guid id, UpdateToDoListItemRequestBody newToDoListItem)
        {
            var toDoListItemToUpdate = new ToDoListItem()
            {
                Id = id,
                ChoreId = newToDoListItem.ChoreId,
                Name = newToDoListItem.Name,
                Description = newToDoListItem.Description,
                IsCompleted = newToDoListItem.IsCompleted,
                DateToDo = newToDoListItem.DateToDo,
            };

            var result = _toDoListItemsRepository.UpdateToDoListItem(toDoListItemToUpdate);

            var updatedToDoListItem = new UpdateToDoListItemResponseBody()
            {
                Id = result.Id,
                ChoreId = result.ChoreId,
                Name = result.Name,
                Description = result.Description,
                IsCompleted = result.IsCompleted,
                DateToDo = result.DateToDo,
            };

            return Task.FromResult(updatedToDoListItem);
        }
    }
}
