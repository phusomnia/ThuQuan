using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class TaiKhoanEndpoints
{
    public static IEndpointRouteBuilder MapTaiKhoanEndpoints(this IEndpointRouteBuilder app)
    {   
        var taiKhoanRepository = app.ServiceProvider.GetRequiredService<ITaiKhoanRepository>();
        
        app.MapGet("/GetTaiKhoan", () =>
        {
            var taikhoan = taiKhoanRepository.GetTaiKhoan();
            return Results.Ok(taikhoan);
        });
        
        app.MapGet("/GetTaiKhoanByVaiTro", (
            DbContext dbAccess,
            string? vaiTro) =>
        {
            if (vaiTro == null || vaiTro == "") return RequireMessage(vaiTro!);
            string query = "SELECT * FROM TaiKhoan WHERE VaiTro = ?";
            var nhanvien = dbAccess.GetData<TaiKhoan>(query, [vaiTro]);
            return Results.Ok(nhanvien);
        });

        app.MapPost("/InsertTaiKhoan", (
            DbContext dbAccess,
            [FromBody] NhanVienRequest nhanVienRequest) =>
        {
            dbAccess.Add(nhanVienRequest);
            dbAccess.SaveChange();
            return Results.Ok();
        });
        
        app.MapPut("/UpdateTaiKhoan", (
            DbContext dbAccess,
            [FromBody] NhanVienRequest nhanVienRequest) =>
        {
            dbAccess.Update(nhanVienRequest);
            dbAccess.SaveChange();
            return Results.Ok();
        });

        return app;
    }

    public static IResult RequireMessage(Object value, [CallerArgumentExpression("value")] string argumentName = "") {
        return Results.BadRequest($"{argumentName} is required");
    }

    public static void printList<T>(T[] obj)
    {
        foreach (var o in obj)
        {
            Console.WriteLine(o);
        }
    }
}