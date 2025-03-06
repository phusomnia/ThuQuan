using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Google.Protobuf.WellKnownTypes;

namespace ThuQuanServer.Dtos.Request;

public class NhanVienRequest
{
    public string    Username { get; set; }
    public string    Password { get; set; }
    public string    Email { get; set; }
    public DateTime  NgayThamGia { get; set; }
    
    [Description("""Vai Tro: Nhan Vien, Quan Ly""")]
    public string    VaiTro { get; set; }
}