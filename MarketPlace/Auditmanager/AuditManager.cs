using MarketPlace.Data;
using MarketPlace.Entityes;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Auditmanager
{
    public class AuditManager:IAuditManager
    {
        private readonly AppDbcontext _context;

        public AuditManager(AppDbcontext context) => _context = context;

        public async Task WriteAuditLog(AuditableEntity log)
        {
            _context.AuditTable.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuditableEntity>> GetAuditLogs() => await _context.AuditTable.ToListAsync();
    }
}
