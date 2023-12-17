using Microsoft.AspNetCore.Mvc;
using Homie.API.DTOs.Ingredient;
using Homie.API.Services;
using Homie.API.Services.Interfaces;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIngredients()
        {
            var allIngredients = await _ingredientService.GetAllIngredients();
            return Ok(allIngredients);
        }

        [HttpGet("{ingredientId}")]
        public async Task<IActionResult> GetIngredientById(Guid itemId)
        {
            var ingredient = await _ingredientService.GetIngredientById(itemId);

            if(ingredient != null)
            {
                return Ok(ingredient);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] CreateIngredientRequestBody ingredient)
        {
            await _ingredientService.AddIngredient(ingredient);
            return Ok();
        }

        [HttpPut("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredientItem(Guid ingredientId, [FromBody] UpdateIngredientRequestBody ingredient)
        {
            await _ingredientService.UpdateIngredient(ingredientId, ingredient);
            return Ok();
        }

        [HttpDelete("{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(Guid ingredientId)
        {
            await _ingredientService.DeleteIngredient(ingredientId);
            return Ok();
        }
    }
}