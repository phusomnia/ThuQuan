using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuTraRepository
{
    public ICollection<PhieuTra> GetPhieuTra();
    public ICollection<PhieuTra> GetPhieuTraByProps(object? values);
    public bool AddPhieuTra();
    public bool UpdatePhieuTra();
}