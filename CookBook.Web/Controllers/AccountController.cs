using CookBook.Web.DTOs.User;
using CookBook.Web.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService) 
            => this.accountService = accountService;

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(UserRegister registerRequest)
        {
            var hasRegistered = await this.accountService
                .CreateUserAsync(registerRequest);

            if (!hasRegistered)
            {
                return BadRequest( new {Message = "Username/email already exists"});
            }

            return Ok();
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(UserLogin loginRequest)
        {
            var result = await this.accountService.LoginUserAsync(loginRequest);
            if (result == null)
            {
                return BadRequest(new {Message = "Username or password incorrect"});
            }

            return Ok(result);
        }
    }
}
