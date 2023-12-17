using Homie.API.DTOs.Chores;
using Homie.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoresController : ControllerBase
    {
        private readonly IChoresService _choresService;

        public ChoresController(IChoresService choresService)
        {
            _choresService = choresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChores()
        {
            var chores = await _choresService.GetAllChores();
            return Ok(chores);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChore(Guid id)
        {
            var chore = await _choresService.GetChore(id);
            return Ok(chore);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChore(CreateChoreRequestBody choreToCreate)
        {
            var createdChore = await _choresService.CreateChore(choreToCreate);
            return Ok(createdChore);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateChore(Guid id, UpdateChoreRequestBody newChore)
        {
            var updatedChore = await _choresService.UpdateChore(id, newChore);
            return Ok(updatedChore);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteChore(Guid id)
        {
            await _choresService.DeleteChore(id);
            return Ok();
        }
    }
}
