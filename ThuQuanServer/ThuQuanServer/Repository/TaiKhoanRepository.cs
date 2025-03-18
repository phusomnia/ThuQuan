using ThuQuanServer.ApplicationContext;
using ThuQuanServer.Dtos.Request;
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
    
    public ICollection<TaiKhoan> GetAccount()
    {
        string query = "SELECT * FROM TaiKhoan";
        var taiKhoan = _dbContext.GetData<TaiKhoan>(query);
        return taiKhoan;
    }

    public ICollection<TaiKhoan> GetAccountByProps(object? values)
    {
        var p = values.GetType().GetProperties();
        
        var query = "SELECT * FROM TaiKhoan WHERE ";
        if (p.Length == 1)
        {
            query += string.Join("", p.Select(p => p.Name)) + "=?";
        }
        else
        {
            query += string.Join("=? AND ", p.Select(p => p.Name)) + "=?";
        }
        Console.WriteLine(query);
        
        var props = p.Select(p => p.GetValue(values)).ToArray();

        var nhanvien = _dbContext.GetData<TaiKhoan>(query, props);
        return nhanvien;
    }
    
    public bool RegisterAccount(TaiKhoanRequestDto taikhoan)
    {
        _dbContext.Add(taikhoan);
        return _dbContext.SaveChange();
    }

    public bool UpdateAccount(TaiKhoanRequestDto taikhoan, int id)
    {
        _dbContext.Update(taikhoan, id);
        return _dbContext.SaveChange();
    }
}