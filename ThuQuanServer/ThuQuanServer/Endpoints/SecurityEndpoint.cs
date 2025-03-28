using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Endpoints;

public static class SecurityEndpoint
{
    public static void MapSecurityEndpoints(this IEndpointRouteBuilder app)
    {
        var authService = app.ServiceProvider.GetRequiredService<IAuthService>();
        var groupName = "Xac thuc";

        app.MapPost("JwtLogin", () =>
        {
            TaiKhoan tk = new TaiKhoan
            {
                Id = 1,
                UserName = "admin",
                Password = "admin",
                Email = "admin@gmail.com",
                NgayThamGia = DateTime.Now,
                VaiTro = "admin"
            };
            var accessToken = authService.GenerateJwtAccessToken(tk);
            
            return Results.Ok(accessToken);
        }).WithTags(groupName);
    }
}