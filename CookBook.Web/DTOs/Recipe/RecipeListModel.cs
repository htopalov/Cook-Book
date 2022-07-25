namespace CookBook.Web.DTOs.Recipe
{
    public class RecipeListModel
    {
        public int RecipesPerPage = 10;

        public int CurrentPage { get; set; } = 1;

        public int? TotalRecipes { get; set; }

        public string? UserId { get; set; }

        public List<RecipeBase>? Recipes { get; set; }
    }
}
