using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.IngredientsList = new List<Ingredient>();
            this.Likes = new List<Like>();
        } 

        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(RecipeDescriptionMaxLength,
            ErrorMessage = RecipeDescriptionLengthExceeded)]
        public string Description { get; set; }

        [Required]
        public int CookingTime { get; set; }

        [Required]
        public int Portions { get; set; }

        [Required]
        [MaxLength(RecipePreparationStepsMaxLength,
            ErrorMessage = RecipePreparationStepsLengthExceeded)]
        public string PreparationSteps { get; set; }

        [ForeignKey(nameof(Image))]
        public Guid ImageId { get; set; }
        public Image Image { get; set; }

        public List<Ingredient> IngredientsList { get; set; }

        public List<Like> Likes { get; set; }
    }
}
