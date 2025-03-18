using ThuQuanServer.Dtos.Request;
using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ITaiKhoanRepository
{
    public ICollection<TaiKhoan> GetAccount();
    public ICollection<TaiKhoan> GetAccountByProps(object? values);
    public bool RegisterAccount(TaiKhoanRequestDto taikhoan);
    public bool UpdateAccount(TaiKhoanRequestDto taikhoan, int id);
}