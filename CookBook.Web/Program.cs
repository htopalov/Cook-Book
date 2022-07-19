using System.Reflection;
using CookBook.Web.Common;
using CookBook.Web.Data;
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

builder
    .Services
    .Configure<RouteOptions>(opt =>
    {
        opt.LowercaseUrls = true;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
