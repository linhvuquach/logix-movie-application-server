using Logix_Movie_Application.Business;
using Logix_Movie_Application.Data;
using Logix_Movie_Application.Extensions;
using Logix_Movie_Application.Interfaces;
using Logix_Movie_Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register CORS middleware
AppExtension.RegisterCORS(builder.Services, builder.Configuration);

// Movie context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MovieDBContext>(options =>
    options.UseSqlServer(connectionString));

// Register services
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IMovie, MovieRepository>();
builder.Services.AddScoped<IUserActivity, UserActivityRepository>();

// Add Authentication and Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.RequireHttpsMetadata = false;
     options.SaveToken = true;
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = builder.Configuration["Jwt:Issuer"],
         ValidAudience = builder.Configuration["Jwt:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
         ClockSkew = TimeSpan.Zero // Override the default clock skew of 5 mins
     };

     builder.Services.AddCors();
 });

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(UserRoles.User, Policies.UserPolicy());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MovieApp API",
        Description = "An ASP.NET Core Web API for managing the movie data",
        Contact = new OpenApiContact
        {
            Name = "linh.vu.quach",
            Url = new Uri("https://linhvuquach.com/"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT Licenese",
            Url = new Uri("https://github.com/linhvuquach/logix-movie-application-server/blob/master/LICENSE"),
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard JWT Authorization header. Example: \"bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
     {
        new OpenApiSecurityScheme {
                 Reference = new OpenApiReference {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
             }
        },
        Array.Empty<string>()
     }
    });
    //options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

// Enable CORS middleware
app.UseCors(builder.Configuration["AllowSpecificOrigin"]);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
