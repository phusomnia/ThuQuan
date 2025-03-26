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
    public static void MapTaiKhoanEndpoints(this IEndpointRouteBuilder app)
    {   
        var dbContext = app.ServiceProvider.GetRequiredService<DbContext>();
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        var passwordHashService = app.ServiceProvider.GetRequiredService<IPasswordHashService>();
        
        var groupName = "Thanh Vien";
        
        // GET API
        app.MapGet("/GetTaiKhoan", (DbContext dbContext) =>
        {
            var taikhoan = taiKhoanRepository.GetAccount();
            return Results.Ok(taikhoan);
        }).WithTags(groupName);
        
        app.MapGet("/GetTaiKhoanById/{id}", ([FromRoute , Required] int? id) =>
        {
            var taikhoan = taiKhoanRepository.GetAccountByProps(new {
                Id = id,
            });
            return Results.Ok(taikhoan);
        }).WithTags(groupName);;
        
        app.MapGet("/GetTaiKhoanByVaiTro/{vaitro}", ([FromRoute , Required] string? vaitro) =>
        {
            // if (string.IsNullOrEmpty(request)) return RequireMessage(vaiTro);
            var taikhoan = taiKhoanRepository.GetAccountByProps(new {
                VaiTro = vaitro,
            });
            return Results.Ok(taikhoan);
        }).WithTags(groupName);

        // POST API
        app.MapPost("/InsertTaiKhoan", (
            [FromBody] TaiKhoanRequestDto thanhVienRequest) =>
        {
            // Check existed username
            var existedUserName = taiKhoanRepository.GetAccount()
                .Where(p => p.UserName == thanhVienRequest.UserName);
            
            if (existedUserName.Any())
            {
                return Results.BadRequest("Ten tai khoan da ton tai");
            }
            
            // Check existed email
            var existedEmail = taiKhoanRepository.GetAccount()
                .Where(p => p.Email == thanhVienRequest.Email);
            
            if (existedEmail.Any())
            {
                return Results.BadRequest("Email is already exist");
            }
            
            // Hash password
            thanhVienRequest.Password = passwordHashService.HashPassword(thanhVienRequest.Password);
            
            // Time
            thanhVienRequest.NgayThamGia = (DateTime.Now);
            
            if (!taiKhoanRepository.AddThanhVien(thanhVienRequest))
            {
                return Results.BadRequest("Insert TaiKhoan failed");
            }
            
            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"Insert thanh vien successully",
                Data = thanhVienRequest
            });
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
        
        // PUT API
        app.MapPut("/UpdateThanhVien", (
            [FromQuery] int id,
            [FromBody] ThanhVienRequestDto thanhVienRequest) =>
        {
            if (!taiKhoanRepository.UpdateThanhVien(thanhVienRequest, id))
            {
                return Results.BadRequest("update ThanhVien failed");
            }
            
            return Results.Ok(new ApiResponse
            {
                Success = true,
                Message = $"update thanh vien {id} successully",
                Data = thanhVienRequest
            });
        }).WithMetadata(typeof(TaiKhoanRequestDto)).WithOpenApi(o =>
        {
            o.Security = new List<OpenApiSecurityRequirement>();
            return o;
        }).WithTags(groupName);
    }
}