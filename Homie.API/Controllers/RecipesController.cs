using Microsoft.AspNetCore.Mvc;
using Homie.API.DTOs.Recipes;
using Homie.API.Services;
using Homie.API.Services.Interfaces;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIngredients()
        {
            var allRecipes = await _recipesService.GetAllRecipes();
            return Ok(allRecipes);
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipesById(Guid recipeId)
        {
            var recipe = await _recipesService.GetRecipeById(recipeId);

            if(recipe != null)
            {
                return Ok(recipe);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] CreateRecipesRequestBody recipe)
        {
            await _recipesService.AddRecipe(recipe);
            return Ok();
        }

        [HttpPut("{recipeId}")]
        public async Task<IActionResult> UpdateIngredientItem(Guid recipeId, [FromBody] UpdateRecipesRequestBody recipe)
        {
            await _recipesService.UpdateRecipe(recipeId, recipe);
            return Ok();
        }

        [HttpDelete("{recipeId}")]
        public async Task<IActionResult> DeleteIngredient(Guid recipeId)
        {
            await _recipesService.DeleteRecipe(recipeId);
            return Ok();
        }
    }
}