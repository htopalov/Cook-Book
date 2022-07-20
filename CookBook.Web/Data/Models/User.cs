using System.ComponentModel.DataAnnotations;

using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.Data.Models
{
    public class User
    {
        public User()
        {
            this.UserRecipes = new List<Recipe>();
            this.LikedRecipes = new List<Like>();
        }

        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(UserEmailMaxLength,
            ErrorMessage = EmailMaxLengthExceeded)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public List<Recipe> UserRecipes { get; set; }

        public List<Like> LikedRecipes { get; set; }
    }
}
