using CookBook.Web.DTOs.Like;

namespace CookBook.Web.Services.Like
{
    public interface ILikeService
    {
        Task<bool> AddLikeAsync(LikeRequest request);
    }
}
