using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuMuonRepository
{
    public ICollection<PhieuDat> GetPhieuDat();
    public ICollection<PhieuDat> GetPhieuDatByProps(object? values);
    public bool CreatePhieuDat();
    public bool UpdatePhieuDat();
}