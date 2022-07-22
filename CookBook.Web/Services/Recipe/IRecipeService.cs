using CookBook.Web.DTOs.Recipe;

namespace CookBook.Web.Services.Recipe
{
    public interface IRecipeService
    {
        Task<string> CreateRecipeAsync(RecipeRequest request);

        Task<RecipeResponse> GetRecipeAsync(Guid id);
    }
}
