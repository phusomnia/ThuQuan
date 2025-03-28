using System.Text;
using Scalar.AspNetCore;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Endpoints;
using ThuQuanServer.Extension;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Repository;
using ThuQuanServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ZstdSharp.Unsafe;

var builder = WebApplication.CreateBuilder(args);

// Add db access
builder.Services.AddSingleton<DbContext>();
builder.Services.AddSingleton<ITaiKhoanRepository , TaiKhoanRepository>();
builder.Services.AddSingleton<IPasswordHashService , PasswordHashService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine($"Token validated successfully");
                return Task.CompletedTask;
            }
        };
    });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    var config = builder.Configuration.GetSection("OpenApi");
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Components = new OpenApiComponents();
        document.Components.SecuritySchemes = config.GetSection("SecuritySchemes").Get<Dictionary<string, OpenApiSecurityScheme>>();
        document.SecurityRequirements = config.GetSection("Security").Get<List<OpenApiSecurityRequirement>>(); 
        return Task.CompletedTask;
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Add Scalar API Reference
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

// Check validation
// app.UseValidationMiddleware();

// Endpoints
app.MapTaiKhoanEndpoints();
app.MapPhieuDatEndpoints();
app.MapPhieuMuonEndpoints();
app.MapPhieuTraEndpoints();
app.MapVatDungEndpoints();
app.MapSecurityEndpoints();

app.Run();

