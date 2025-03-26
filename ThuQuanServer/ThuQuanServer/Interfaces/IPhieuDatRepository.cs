using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuDatRepository
{
    public ICollection<PhieuDat> GetPhieuDat();
    public ICollection<PhieuDat> GetPhieuDatByProps(object? values);
    public bool AddPhieuDat();
    public bool UpdatePhieuDat();
}