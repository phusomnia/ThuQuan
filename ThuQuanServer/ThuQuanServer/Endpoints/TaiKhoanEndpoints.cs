using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;
using ThuQuanServer.Services;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace ThuQuanServer.Endpoints;

public static class TaiKhoanEndpoints
{
    public static IEndpointRouteBuilder MapTaiKhoanEndpoints(this IEndpointRouteBuilder app)
    {   
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        
        // GET API
        app.MapGet("/GetTaiKhoan", (DbContext dbContext) =>
        {
            var taikhoan = taiKhoanRepository.GetTaiKhoan();
            return Results.Ok(taikhoan);
        });
        
        app.MapGet("/GetTaiKhoanById/{id}", ([FromRoute , Required] int? id) =>
        {
            // if (string.IsNullOrEmpty(request)) return RequireMessage(vaiTro);
            var taikhoan = taiKhoanRepository.GetTaiKhoanByProps(new {
                Id = id,
            });
            return Results.Ok(taikhoan);
        });
        
        app.MapGet("/GetTaiKhoanByVaiTro/{vaitro}", ([FromRoute , Required] string? vaitro) =>
        {
            // if (string.IsNullOrEmpty(request)) return RequireMessage(vaiTro);
            var taikhoan = taiKhoanRepository.GetTaiKhoanByProps(new {
                VaiTro = vaitro,
            });
            return Results.Ok(taikhoan);
        });

        // POST API
        app.MapPost("/InsertTaiKhoan", (
            [FromBody] TaiKhoanRequestDto nhanVienRequest) =>
        {
            // Check existed username
            var existedUserName = taiKhoanRepository.GetTaiKhoan()
                .Where(p => p.UserName == nhanVienRequest.UserName);
            
            if (existedUserName.Any())
            {
                return Results.BadRequest("Username is already exist");
            }
            
            // Check existed email
            var existedEmail = taiKhoanRepository.GetTaiKhoan()
                .Where(p => p.Email == nhanVienRequest.Email);
            
            if (existedEmail.Any())
            {
                return Results.BadRequest("Email is already exist");
            }

            // Hash password
            nhanVienRequest.Password = passwordHashService.HashPassword(nhanVienRequest.Password);

            // Time
            nhanVienRequest.NgayThamGia = (DateTime.Now);
            Console.WriteLine(nhanVienRequest.NgayThamGia);
            
            if (!taiKhoanRepository.InsertTaiKhoan(nhanVienRequest))
            {
                return Results.BadRequest("Insert TaiKhoan failed");
            }

            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = "Insert TaiKhoan successully",
                Data = nhanVienRequest
            });
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        });
        
        // PUT API
        app.MapPut("/UpdateTaiKhoan/{id}", (
            [Required] int id,
            [FromBody] TaiKhoanRequestDto nhanVienRequest) =>
        {
            // taiKhoanRepository.UpdateTaiKhoan(nhanVienRequest, id);
            return Results.Ok();
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        });;

        return app;
    }
    
    public static void PrintList(object?[] obj)
    {
        foreach (var o in obj)
        {
            Console.WriteLine(o);
        }
    }
}