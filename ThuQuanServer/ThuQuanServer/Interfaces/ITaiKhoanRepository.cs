using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ITaiKhoanRepository
{
    public ICollection<TaiKhoan> GetTaiKhoan();
}