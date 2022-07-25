using CookBook.Web.DTOs.Recipe;
using CookBook.Web.Filters;
using CookBook.Web.Services.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet(nameof(Details))]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await this.recipeService
                .GetRecipeAsync(id);

            if (result == null)
            {
                return NotFound("Recipe not found");
            }

            return Ok(result);
        }

        [AuthToken]
        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create([FromForm] RecipeRequest request)
        {
            var result = await this.recipeService
                .CreateRecipeAsync(request);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Recipe name already exists");
            }

            return Created(nameof(Details), new { id = result });
        }

        [AuthToken]
        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await this.recipeService
                .DeleteRecipeAsync(id);

            if (!result)
            {
                return NotFound("Recipe does not exist");
            }

            return NoContent();
        }

        [AuthToken]
        [HttpPut(nameof(Edit))]
        public async Task<IActionResult> Edit(Guid id, [FromForm]RecipeEditRequest request)
        {
            var result = await this.recipeService
                .EditRecipeAsync(id, request);

            if (!result)
            {
                return NotFound("Recipe not found");
            }

            return Ok();
        }

        [AuthToken]
        [HttpPost(nameof(All))]
        public async Task<IActionResult> All([FromBody]RecipeListModel request)
        {
            var result = await this.recipeService
                .GetRecipesAsync(
                    request.UserId,
                    request.RecipesPerPage,
                    request.CurrentPage);

            return Ok(result);
        }
    }
}
