using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class TaiKhoanRepository : ITaiKhoanRepository
{
    private readonly DbContext _dbContext;
    
    public TaiKhoanRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ICollection<TaiKhoan> GetTaiKhoan()
    {
        string query = "SELECT * FROM TaiKhoan";
        var taikhoan = _dbContext.GetData<TaiKhoan>(query);
        return taikhoan;
    }
}