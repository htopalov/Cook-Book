using System.ComponentModel.DataAnnotations;

using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.DTOs.User
{
    public class UserRegister
    {
        [Required]
        [MinLength(UsernameMinLength,
            ErrorMessage = UsernameMinLengthError)]
        [MaxLength(UsernameMaxLength,
            ErrorMessage = UsernameMaxLengthExceeded)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(UserEmailMaxLength,
            ErrorMessage = EmailMaxLengthExceeded)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
