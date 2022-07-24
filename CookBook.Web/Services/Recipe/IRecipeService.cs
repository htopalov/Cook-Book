using CookBook.Web.DTOs.Recipe;

namespace CookBook.Web.Services.Recipe
{
    public interface IRecipeService
    {
        Task<string> CreateRecipeAsync(RecipeRequest request);

        Task<RecipeResponse> GetRecipeAsync(Guid id);

        Task<bool> DeleteRecipeAsync(Guid id);

        Task<bool> EditRecipeAsync(Guid id, RecipeEditRequest request);

        Task<List<RecipeResponse>> GetRecipesAsync(string? userId = null);
    }
}
