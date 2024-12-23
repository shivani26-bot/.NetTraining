using ShoppingAPI.Contexts;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    //public class AuditLogRepository
    //{
    //}

    public class AuditLogRepository : Repository<AuditLog, int>
    {
        public AuditLogRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        public override ICollection<AuditLog> Get()
        {
            var auditLogs = _shoppingContext.AuditLogs.ToList();
            if (auditLogs.Count == 0)
            {
                throw new RepositoryEmptyException("No logs found");
            }
            return auditLogs;
        }

        public override AuditLog Get(int key)
        {
            var auditLog = _shoppingContext.AuditLogs.FirstOrDefault(a => a.LogId == key);
            if (auditLog == null)
            {
                throw new EntityNotFoundException("Log not found");
            }
            return auditLog;
        }
    }
}
