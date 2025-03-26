using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IVatDungRepository
{
    public ICollection<VatDung> GetVatDung();
    public ICollection<VatDung> GetVatDungByProps(object? values);
    public bool AddVatDung();
    public bool UpdateVatDung();
}