// TODO Add using statements
using Microsoft.EntityFrameworkCore;
using GameFinder.Data;
using GameFinder.Services.GameConsole;
using GameFinder.Services.GameGenre;
using GameFinder.Services.Game;
using GameFinder.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Different connection strings for each member
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionNick");
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionZach");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMary");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// TODO Add Services for Dependency Injection
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IGame, Game>();
builder.Services.AddScoped<IGameGenre, GameGenre>();
builder.Services.AddScoped<IGameConsole, GameConsole>();

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
