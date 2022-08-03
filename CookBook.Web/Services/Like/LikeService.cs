using AutoMapper;
using CookBook.Web.Data;
using CookBook.Web.DTOs.Like;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Web.Services.Like
{
    public class LikeService : ILikeService
    {
        private readonly CookBookDbContext dbContext;
        private readonly IMapper mapper;

        public LikeService(CookBookDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<bool> AddLikeAsync(LikeRequest request)
        {
            var isLiked =
                await this.dbContext
                    .Likes
                    .AnyAsync(l => l.RecipeId == request.RecipeId &&
                                   l.UserId == request.UserId);

            if (isLiked)
            {
                return false;
            }

            var recipe = await this.dbContext
                .Recipes
                .FindAsync(request.RecipeId);

            if (recipe.UserId == request.UserId)
            {
                return false;
            }

            var like = this.mapper
                .Map<Data.Models.Like>(request);

            await this.dbContext
                .Likes
                .AddAsync(like);

            var result = await this.dbContext
                .SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> HasUserLikedRecipe(LikeRequest request)
        {
            var isLiked =
                await this.dbContext
                    .Likes
                    .AnyAsync(l => l.RecipeId == request.RecipeId &&
                                   l.UserId == request.UserId);

            if (isLiked)
            {
                return true;
            }

            return false;
        }
    }
}
