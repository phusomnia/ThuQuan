namespace ThuQuanServer.Interfaces;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string providedPassword);
}