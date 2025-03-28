using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IAuthService
{
    string GenerateJwtAccessToken(TaiKhoan user);
}