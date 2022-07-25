namespace CookBook.Web.DTOs.Recipe
{
    public class RecipeBase : IRecipeBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }
    }
}
