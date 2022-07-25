namespace CookBook.Web.DTOs.Recipe
{
    public interface IRecipeBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }
    }
}
