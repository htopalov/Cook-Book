using CookBook.Web.Data.Models;
using CookBook.Web.DTOs.User;

namespace CookBook.Web.Services.Account
{
    public interface IAccountService
    {
        Task<bool> CreateUserAsync(UserRegister request);

        Task<User?> GetUserAsync(string id);

        Task<AuthUserResponse> LoginUserAsync(UserLogin request);

    }
}
