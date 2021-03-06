using AutoMapper;
using CookBook.Web.Data;
using CookBook.Web.Data.Models;
using CookBook.Web.DTOs.Recipe;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Web.Services.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly CookBookDbContext dbContex;
        private readonly IMapper mapper;

        public RecipeService(CookBookDbContext dbContex, IMapper mapper)
        {
            this.dbContex = dbContex;
            this.mapper = mapper;
        }

        public async Task<RecipeResponse> GetRecipeAsync(Guid id)
        {
            var recipe = await this.dbContex
                .Recipes
                .Include(r=>r.IngredientsList)
                .Include(r=>r.Image)
                .Include(r=>r.Likes)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return null;
            }

            return this.mapper.Map<RecipeResponse>(recipe);
        }

        public async Task<string> CreateRecipeAsync(RecipeRequest request)
        {
            var recipe = await this.dbContex
                .Recipes
                .FirstOrDefaultAsync(r => r.Name == request.Name);

            if (recipe != null)
            {
                return string.Empty;
            }

            recipe = this.mapper
                .Map<Data.Models.Recipe>(request);

            recipe.Image = await ProcessImageRequest(request.Image);

            await this.dbContex
                .AddAsync(recipe);

            var result = await this.dbContex
                .SaveChangesAsync();

            if (result > 0)
            {
                return recipe.Id.ToString();
            }

            return string.Empty;
        }

        public async Task<bool> DeleteRecipeAsync(Guid recipeId)
        {
            var recipe = await this.dbContex
                .Recipes
                .FindAsync(recipeId);

            if (recipe == null)
            {
                return false;
            }

            this.dbContex
                .Recipes
                .Remove(recipe);

            var result = await this.dbContex
                .SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> EditRecipeAsync(Guid id, RecipeEditRequest request)
        {
            var recipe = await this.dbContex
                .Recipes
                .Include(r=>r.Image)
                .Include(r=>r.IngredientsList)
                .FirstOrDefaultAsync(r=> r.Id == id);

            if (recipe == null)
            {
                return false;
            }

            this.mapper
                .Map(request, recipe);

            if (request.Image != null)
            {
                recipe.Image = await ProcessImageRequest(request.Image);
            }

            this.dbContex.Recipes.Update(recipe);

            var updated = await dbContex.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<List<RecipeResponse>> GetRecipesAsync(string? userId = null)
        {
            //var recipes = await this.dbContex
            //    .Recipes
            //    .Include(r=>r.Image)
            //    .Include(r=>r.IngredientsList)
            //    .Include(r=>r.Likes)
            //    .Take(10)
            //    .ToListAsync();

            var queryableRecipes = this.dbContex.Recipes.AsQueryable();
            if (!string.IsNullOrEmpty(userId))
            {
                queryableRecipes = queryableRecipes.Where(r => r.UserId.ToString() == userId);
            }

            var recipes = await queryableRecipes
                .Include(r => r.Image)
                .Include(r => r.IngredientsList)
                .Include(r => r.Likes)
                .Take(5)
                .ToListAsync();

            return this.mapper.Map<List<RecipeResponse>>(recipes);
        }

        private async Task<Image> ProcessImageRequest(IFormFile imageFromForm)
        {
            await using var memoryStream = new MemoryStream();
            await imageFromForm.CopyToAsync(memoryStream);
            return new Image { DataBytes = memoryStream.ToArray() };
        }
    }
}
