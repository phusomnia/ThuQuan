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
    
    public bool AddThanhVien(TaiKhoanRequestDto taikhoan)
    {
        // Add TaiKhoan
        _dbContext.Add<TaiKhoan>(taikhoan);
        var lastInsertId = _dbContext.GetLastInsertId();
        Console.WriteLine(lastInsertId);
        
        // Create new ThanhVien
        ThanhVienRequestDto thanhvien = new ThanhVienRequestDto();
        thanhvien.IdTaiKhoan = lastInsertId;
        _dbContext.Add<ThanhVien>(thanhvien);
        
        // Save changes
        return _dbContext.SaveChange();
    }

    public bool UpdateThanhVien(ThanhVienRequestDto thanhvien, int idTaiKhoan)
    {
        // query find ThanhVien where IdTaiKhoan
        var query = "SELECT * FROM ThanhVien WHERE IdTaiKhoan = ?";
        // Take first element from list
        var idThanhVien = _dbContext.GetData<ThanhVien>(query, idTaiKhoan).First().Id;
        // Assign id to thanhvien
        thanhvien.IdTaiKhoan = idTaiKhoan;
        
        // Update thanhvien
        _dbContext.Update<ThanhVien>(thanhvien, idThanhVien);
        
        // Save 
        return _dbContext.SaveChange();
    }
}