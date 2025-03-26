using ThuQuanServer.Models;

namespace ThuQuanServer.Interfaces;

public interface IPhieuMuonRepository
{
    public ICollection<PhieuMuon> GetPhieuMuon();
    public ICollection<PhieuMuon> GetPhieuMuonByProps(object? values);
    public bool AddPhieuMuon();
    public bool UpdatePhieuMuon();
}