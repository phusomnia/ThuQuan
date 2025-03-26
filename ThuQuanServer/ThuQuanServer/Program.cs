using Scalar.AspNetCore;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Endpoints;
using ThuQuanServer.Extension;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Repository;
using ThuQuanServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add db access
builder.Services.AddSingleton<DbContext>();
builder.Services.AddSingleton<ITaiKhoanRepository , TaiKhoanRepository>();
builder.Services.AddSingleton<IPasswordHashService , PasswordHashService>();

builder.Services.AddAuthorization();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

// Check validation
// app.UseValidationMiddleware();

// Endpoints
app.MapTaiKhoanEndpoints();
app.MapPhieuDatEndpoints();
app.MapPhieuMuonEndpoints();
app.MapPhieuTraEndpoints();
app.MapVatDungEndpoints();

app.Run();

