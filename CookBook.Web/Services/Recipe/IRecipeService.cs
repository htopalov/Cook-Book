using CookBook.Web.DTOs.Recipe;

namespace CookBook.Web.Services.Recipe
{
    public interface IRecipeService
    {
        Task<string> CreateRecipeAsync(RecipeRequest request);

        Task<RecipeResponse> GetRecipeAsync(Guid id);

        Task<bool> DeleteRecipeAsync(Guid id);

        Task<bool> EditRecipeAsync(Guid id, RecipeEditRequest request);

        Task<RecipeListModel> GetRecipesAsync(
            string? userId = null,
            int recipesPerPage = int.MaxValue,
            int currentPage = 1);

        Task<List<RecipeGuestResponse>> GetGuestRecipesAsync();
    }
}
