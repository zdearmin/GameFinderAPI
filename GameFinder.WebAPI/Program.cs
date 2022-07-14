// TODO Add using statements
using Microsoft.EntityFrameworkCore;
using GameFinder.Data;
using GameFinder.Services.UserService;
using GameFinder.Services.GameService;
using GameFinder.Services.GameGenreService;
using GameFinder.Services.GameConsoleService;

var builder = WebApplication.CreateBuilder(args);

// Different connection strings for each member
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionNick");
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionZach");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMary");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// TODO Add Services for Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameGenreService, GameGenreService>();
builder.Services.AddScoped<IGameConsoleService, GameConsoleService>();

// Add services to the container.
builder.Services.AddControllers();
// More about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
