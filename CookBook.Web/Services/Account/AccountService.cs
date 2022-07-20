using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using CookBook.Web.Data;
using CookBook.Web.Data.Models;
using CookBook.Web.DTOs.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CookBook.Web.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly CookBookDbContext dbContext;
        private readonly IConfiguration config;
        private readonly IMapper mapper;
        private readonly byte[] keyBytes;

        public AccountService(CookBookDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.config = config;
            this.keyBytes = Encoding.UTF8.GetBytes(this.config
                .GetSection("TokenSecretKey")
                .Value);
        }

        public async Task<bool> CreateUserAsync(UserRegister request)
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == request.Email 
                                          || u.Username == request.Username);

            if (user != null)
            {
                return false;
            }

            var dbUser = this.mapper.Map<User>(request);

            dbUser.PasswordHash = PasswordHasher(request.Password);

            await this.dbContext.Users.AddAsync(dbUser);

            var created = await this.dbContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<User?> GetUserAsync(string id) 
            => await this.dbContext
                .Users
                .FirstOrDefaultAsync(x => x.Id.ToString() == id);

        public async Task<AuthUserResponse> LoginUserAsync(UserLogin request)
        {
            var user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
            {
                return null;
            }

            var isPasswordValid = user.PasswordHash == PasswordHasher(request.Password);

            if (!isPasswordValid)
            {
                return null;
            }

            var token = GenerateToken(user);

            return new AuthUserResponse(user, token);
        }


        private string PasswordHasher(string rawPassword)
        {
            using var hasher = SHA256.Create();
            var bytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
            var hash = BitConverter
                .ToString(bytes)
                .Replace("-", "")
                .ToLower();

            return hash;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
