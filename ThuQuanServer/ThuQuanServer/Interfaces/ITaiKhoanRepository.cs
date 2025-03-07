using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ITaiKhoanRepository
{
    public ICollection<TaiKhoan> GetTaiKhoan();
    public ICollection<TaiKhoan> GetTaiKhoanByProps(object? values);
    public bool InsertTaiKhoan(TaiKhoanRequestDto taikhoan);
    public bool UpdateTaiKhoan(TaiKhoanRequestDto taikhoan, int id);
}