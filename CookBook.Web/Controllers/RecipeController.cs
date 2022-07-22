using CookBook.Web.DTOs.Recipe;
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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await this.recipeService
                .GetRecipeAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create([FromBody]RecipeRequest request)
        {
            var result = await this.recipeService
                .CreateRecipeAsync(request);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest();
            }

            return Created(nameof(Details), new {id = result});
        }
    }
}
