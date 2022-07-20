using CookBook.Web.DTOs.User;
using CookBook.Web.Filters;
using CookBook.Web.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService) 
            => this.accountService = accountService;

        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody]UserRegister registerRequest)
        {
            var hasRegistered = await this.accountService
                .CreateUserAsync(registerRequest);

            if (!hasRegistered)
            {
                return BadRequest( new {Message = "Email already exists"});
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(UserLogin loginRequest)
        {
            var result = await this.accountService.LoginUserAsync(loginRequest);
            if (result == null)
            {
                return BadRequest(new {Message = "Email or password incorrect"});
            }

            return Ok(result);
        }

        [AuthToken]
        [HttpGet(nameof(Logout))]
        public IActionResult Logout()
            => Ok();
    }
}
