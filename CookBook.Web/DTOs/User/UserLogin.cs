using System.ComponentModel.DataAnnotations;

using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.DTOs.User
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        [MaxLength(UserEmailMaxLength,
            ErrorMessage = EmailMaxLengthExceeded)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
