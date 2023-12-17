using Microsoft.AspNetCore.Mvc;
using Homie.API.DTOs.Food;
using Homie.API.Services;
using Homie.API.Services.Interfaces;

namespace Homie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoodItems()
        {
            var allFood = await _foodService.GetAllFoodItems();
            return Ok(allFood);
        }

        [HttpGet("{foodId}")]
        public async Task<IActionResult> GetFoodItemById(Guid itemId)
        {
            var food = await _foodService.GetFoodItemById(itemId);

            if(food != null)
            {
                return Ok(food);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodItem([FromBody] CreateFoodRequestBody food)
        {
            await _foodService.AddFoodItem(food);
            return Ok();
        }

        [HttpPut("{foodId}")]
        public async Task<IActionResult> UpdateFoodItem(Guid foodId, [FromBody] UpdateFoodRequestBody food)
        {
            await _foodService.UpdateFoodItem(foodId, food);
            return Ok();
        }

        [HttpDelete("{foodId}")]
        public async Task<IActionResult> DeleteFoodItem(Guid foodId)
        {
            await _foodService.DeleteFoodItem(foodId);
            return Ok();
        }
    }
}