using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CookBook.Web.Services.Account;
using Microsoft.IdentityModel.Tokens;

namespace CookBook.Web.Middlewares.Token
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration config;
        private readonly byte[] keyBytes;

        public TokenMiddleware(RequestDelegate next, IConfiguration config)
        {
            this.next = next;
            this.config = config;
            this.keyBytes = Encoding.UTF8.GetBytes(this.config
                .GetSection("TokenSecretKey")
                .Value);
        }

        public async Task Invoke(HttpContext context, IAccountService accountService)
        {
            var token = context
                .Request
                .Headers["AuthToken"]
                .FirstOrDefault()?
                .Split(" ")
                .Last();

            if (token != null)
            {
                AttachToContext(context, accountService, token);
            }

            await this.next(context);
        }

        private async Task AttachToContext(HttpContext context, IAccountService accountService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwt = (JwtSecurityToken)validatedToken;
                var userId = jwt.Claims.First(x=>x.Type == "id").Value;
                context.Items["User"] = await accountService.GetUserAsync(userId);

            }
            catch (Exception)
            {
                //user not attached to context == Unathorized(401)
            }
        }
    }
}
