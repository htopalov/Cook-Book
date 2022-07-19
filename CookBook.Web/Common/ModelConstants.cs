namespace CookBook.Web.Common
{
    public static class ModelConstants
    {
        //max length
        public const int ModelIdMaxLength = 36;
        public const int RecipeDescriptionMaxLength = 5000;
        public const int RecipePreparationStepsMaxLength = 5000;
        public const int UsernameMaxLength = 50;
        public const int UserEmailMaxLength = 50;
        public const int IngredientMaxLength = 50;

        //error messages
        public const string UsernameMaxLengthExceeded = "Username too long";
        public const string EmailMaxLengthExceeded = "Email too long";
        public const string RecipeDescriptionLengthExceeded = "Description too long";
        public const string RecipePreparationStepsLengthExceeded = "Too many preparation steps";
    }
}
