using System.Reflection;
using CookBook.Web.Common;
using CookBook.Web.Data;
using CookBook.Web.Middlewares.Token;
using CookBook.Web.Services.Account;
using CookBook.Web.Services.Recipe;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder
    .Services
    .AddControllers();

builder
    .Services
    .AddEndpointsApiExplorer();

builder
    .Services
    .AddSwaggerGen();

builder
    .Services
    .AddDbContext<CookBookDbContext>(options =>
        options.UseSqlServer(connectionString));

builder
    .Services
    .AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

//services injection
builder
    .Services
    .AddScoped<IAccountService, AccountService>();

builder
    .Services
    .AddScoped<IRecipeService, RecipeService>();


builder
    .Services
    .Configure<RouteOptions>(opt =>
    {
        opt.LowercaseUrls = true;
    });

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:3000"));

app.UseMiddleware<TokenMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
