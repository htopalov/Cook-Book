using System.ComponentModel.DataAnnotations;
using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.Data.Models
{
    public class Ingredient
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(IngredientMaxLength)]
        public string NameAndQuantity { get; set; }
    }
}
