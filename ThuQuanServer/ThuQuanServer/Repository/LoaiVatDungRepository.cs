using ThuQuanServer.Interfaces;
using ThuQuanServer.Models;

namespace ThuQuanServer.Repository;

public class LoaiVatDungRepository : IVatDungRepository
{
    public ICollection<VatDung> GetVatDung()
    {
        throw new NotImplementedException();
    }

    public ICollection<VatDung> GetVatDungByProps(object? values)
    {
        throw new NotImplementedException();
    }

    public bool AddVatDung()
    {
        throw new NotImplementedException();
    }

    public bool UpdateVatDung()
    {
        throw new NotImplementedException();
    }
}