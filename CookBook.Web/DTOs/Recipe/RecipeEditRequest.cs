using System.ComponentModel.DataAnnotations;

using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.DTOs.Recipe
{
    public class RecipeEditRequest
    {
        [Required]
        [MinLength(RecipeNameMinLength,
            ErrorMessage = RecipeNameMinLengthError)]
        [MaxLength(RecipeNameMaxLength,
            ErrorMessage = RecipeNameMaxLengthExceeded)]
        public string Name { get; set; }

        [Required]
        [MinLength(RecipeDescriptionMinLength,
            ErrorMessage = RecipeDescriptionMinLengthError)]
        [MaxLength(RecipeDescriptionMaxLength,
            ErrorMessage = RecipeDescriptionLengthExceeded)]
        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CookingTime { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Portions { get; set; }

        [Required]
        [MinLength(RecipePreparationStepsMinLength,
            ErrorMessage = RecipePreparationStepsMinLengthError)]
        [MaxLength(RecipePreparationStepsMaxLength,
            ErrorMessage = RecipePreparationStepsLengthExceeded)]
        public string Steps { get; set; }

        public string Ingredients { get; set; }

        public IFormFile? Image { get; set; }

        public string UserId { get; set; }
    }
}
