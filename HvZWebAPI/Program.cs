using HvZWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Repositories;
using HvZWebAPI.Interfaces;
using Microsoft.Data.SqlClient;
using dotenv.net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
DotEnv.Load();
//


string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION") ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HvZDbContext>(opt => opt.UseSqlServer(connectionString)); 

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
