using AuditLogMicroservice.Contexts;
using AuditLogMicroservice.Models;

namespace AuditLogMicroservice.Repositories
{
   

    public class AuditLogRepository : Repository<AuditLog, int>
    {

        public AuditLogRepository(AuditContext auditContext)
        {
            _auditContext = auditContext;
        }
        public override ICollection<AuditLog> Get()
        {
            var auditLogs = _auditContext.AuditLogs.ToList();
            if (auditLogs.Count == 0)
            {
                throw new Exception("No logs found");
            }
            return auditLogs;
        }

    }
}
