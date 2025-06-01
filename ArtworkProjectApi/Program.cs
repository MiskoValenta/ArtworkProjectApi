using ArtworkProjectApi.Authentication;
using ArtworkProjectApi.Authentication.Interface;
using ArtworkProjectApi.Data;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories;
using ArtworkProjectApi.Repositories.Interfaces;
using ArtworkProjectApi.Services;
using ArtworkProjectApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ===========================
// Load and Bind JwtSettings from appsettings.json
// ===========================
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JWTSettings>();

// ===========================
// Add DbContext
// ===========================
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// ===========================
// Add Identity
// ===========================
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// ===========================
// JWT Authentication
// ===========================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });

builder.Services.AddAuthorization();

// ===========================
// AutoMapper + Dependency Injection
// ===========================
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Services
builder.Services.AddScoped<IArtworkService, ArtworkService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
builder.Services.AddScoped<ITokenService, TokenGenerator>();// -> asi se nevyužívá? nebo nevím proč to pyští 

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===========================
// SEEDING TEST ADMINA (POUZE PRO VÝVOJ)
// Pokud tento projekt půjde do produkce,
// ❌ ODSTRAŇ TUTO ČÁST KÓDU NEBO ji ZABLOKUJ! ❌
// ===========================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    if (!dbContext.Admins.Any())
    {
        dbContext.Admins.Add(new Admin
        {
            Id = 1,
            Username = "admin",
            Password = "password123" // ⚠️ Pouze pro testování – není hashováno!
        });
    }

    if (!dbContext.Artworks.Any())
    {
        dbContext.Artworks.AddRange(
            new Artwork
            {
                Id = 1,
                Title = "Slunečnice",
                Description = "Krásný obraz slunečnic v poli.",
                Price = 1500.00m,
                ImageUrl = "https://example.com/images/slunecnice.jpg",
                GenreId = 1
            },
            new Artwork
            {
                Id = 2,
                Title = "Noční krajina",
                Description = "Temná krajina pod hvězdnou oblohou.",
                Price = 2300.00m,
                ImageUrl = "https://example.com/images/nocni_krajina.jpg",
                GenreId = 2
            }
        );
    }

    dbContext.SaveChanges();
}

// ===========================
// Middleware
// ===========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();