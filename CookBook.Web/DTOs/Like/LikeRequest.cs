namespace CookBook.Web.DTOs.Like
{
    public class LikeRequest
    {
        public Guid UserId { get; set; }

        public Guid RecipeId { get; set; }
    }
}
