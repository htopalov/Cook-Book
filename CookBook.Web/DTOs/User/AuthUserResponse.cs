namespace CookBook.Web.DTOs.User
{
    public class AuthUserResponse
    {
        public AuthUserResponse(Data.Models.User user, string token)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.Token = token;
        }
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
