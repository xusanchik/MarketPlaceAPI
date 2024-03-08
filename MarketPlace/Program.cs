using MarketPlace.Auditmanager;
using MarketPlace.Data;
using MarketPlace.Entityes;
using MarketPlace.Middlawere;
using MarketPlace.Middleware;
using MarketPlace.Repository;
using MarketPlace.Service;
using MarketPlace.Service.IService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using FluentValidation;
using MarketPlace.Dto_s;
using MarketPlace.FluentValidation;
using MarketPlace.Interfaces;
using MarketPlace.AutoMapperConfguration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    }); options.AddSecurityRequirement(new OpenApiSecurityRequirement
{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
});

}));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbcontext>();

builder.Services.AddDbContext<AppDbcontext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.EnableSensitiveDataLogging();
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5069/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asfsafsasafjsafjksafksafsafsafsafasfasfafasfsafasfsafsafassaf"))
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuditManager, AuditManager>();
builder.Services.AddScoped<IFoodMarketRepository, FoodMarketRepository>();
builder.Services.AddScoped<IValidator<UserDto>, UserValidation>();
builder.Services.AddScoped<IValidator<FoodDto>, FoodValidation>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<AdressRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<FoodMarketRepository>();
builder.Services.AddScoped<FoodRepository>();
builder.Services.AddScoped<PaymentRrpository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<GlobalExceptionHandlingMiddlewareConventional>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization(); 
app.UseMiddleware<AuditMiddleware>();
app.MapControllers();
app.Run();
