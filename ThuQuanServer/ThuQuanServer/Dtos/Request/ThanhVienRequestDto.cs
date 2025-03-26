using System.ComponentModel.DataAnnotations;

namespace ThuQuanServer.Dtos.Request;

public class ThanhVienRequestDto
{
    [Required(ErrorMessage = "Vui long nhap ho ten")]
    [Length(10, 100, ErrorMessage = "Ho ten phai tu 10 ky tu den 100 ky tu")]
    public string HoTen { get; set; }
    
    [Required(ErrorMessage = "Vui long nhap so dien thoai")]
    [Length(11, 11, ErrorMessage = "So dien thoai co dinh dang la 11 ky tu")]
    public string SoDienThoai { get; set; }
    
    public int? IdTaiKhoan { get; set; }
}