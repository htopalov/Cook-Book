namespace CookBook.Web.DTOs.User
{
    public class AuthUserResponse
    {
        public AuthUserResponse(Data.Models.User user, string authToken)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.AuthToken = authToken;
        }
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string AuthToken { get; set; }
    }
}
