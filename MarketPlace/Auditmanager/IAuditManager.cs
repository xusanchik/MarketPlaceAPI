using MarketPlace.Entityes;

namespace MarketPlace.Auditmanager
{
    public interface IAuditManager
    {
        Task WriteAuditLog(AuditableEntity log);
        Task<IEnumerable<AuditableEntity>> GetAuditLogs();
    }
}
