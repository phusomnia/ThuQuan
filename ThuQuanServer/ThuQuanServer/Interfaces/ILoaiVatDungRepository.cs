using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface ILoaiVatDungRepository
{
    public ICollection<LoaiVatDung> GetLoaiVatDung();
    public ICollection<LoaiVatDung> GetLoaiVatDungByProps(object? values);
    public bool AddLoaiVatDung();
    public bool UpdateLoaiVatDung();
}