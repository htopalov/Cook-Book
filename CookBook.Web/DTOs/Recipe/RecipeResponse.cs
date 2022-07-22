namespace CookBook.Web.DTOs.Recipe
{
    public class RecipeResponse
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CookingTime { get; set; }

        public int Portions { get; set; }

        public string Steps { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }

        public string[] IngredientsList { get; set; }

        public int Likes { get; set; }
    }
}
