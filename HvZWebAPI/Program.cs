using HvZWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Repositories;
using HvZWebAPI.Interfaces;
using Microsoft.Data.SqlClient;
using dotenv.net;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using HvZWebAPI.Utils;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HvZ game API",
        Description = "An ASP.NET Core Web API for managing HvZ games",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Contract",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://example.com/license")
        }
    });


    var schema = new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"

        },
    };

    options.AddSecurityDefinition("Bearer", schema);

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement {
            {
                schema, new[] { "Bearer" }
            }
        }
      );


    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IKillRepository, KillRepository>();
builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
DotEnv.Load();
//


string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION") ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HvZDbContext>(opt => opt.UseSqlServer(connectionString));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKeyResolver = (token, securityToken, kid, paramaters) =>
            {
                var client = new HttpClient();
                var keyURI = "https://hvz-2022-keycloak.herokuapp.com/auth/realms/HvZ/protocol/openid-connect/certs";

                var response = client.GetAsync(keyURI).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);

                return keys.Keys;
            },
            ValidIssuers = new List<string>()
            {
                "https://hvz-2022-keycloak.herokuapp.com/auth/realms/HvZ",
            },
            ValidAudience = "account"
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwaggerUI();
app.UseSwagger();

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();
