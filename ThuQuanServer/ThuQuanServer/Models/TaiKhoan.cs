using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

namespace ThuQuanServer.Models;

public class TaiKhoan
{
    public int       Id { get; set; }
    public string    UserName { get; set; }
    public string    Password { get; set; }
    public string    Email { get; set; }
    public DateTime  NgayThamGia { get; set; }
    public string    VaiTro { get; set; }
}