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
        public const int RecipeNameMaxLength = 50;

        //min length
        public const int UsernameMinLength = 3;
        public const int RecipeNameMinLength = 3;
        public const int RecipeDescriptionMinLength = 50;
        public const int RecipePreparationStepsMinLength = 50;

        //error messages
        public const string UsernameMaxLengthExceeded = "Username too long";
        public const string UsernameMinLengthError = "Username too short";
        public const string EmailMaxLengthExceeded = "Email too long";
        public const string RecipeNameMaxLengthExceeded = "Name too long";
        public const string RecipeNameMinLengthError = "Name too short";
        public const string RecipeDescriptionLengthExceeded = "Description too long";
        public const string RecipeDescriptionMinLengthError = "Description too short";
        public const string RecipePreparationStepsLengthExceeded = "Too many preparation steps";
        public const string RecipePreparationStepsMinLengthError = "Add more steps";
    }
}
