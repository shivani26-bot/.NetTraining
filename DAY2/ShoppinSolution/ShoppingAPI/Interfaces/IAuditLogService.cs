using ShoppingAPI.Models;

namespace ShoppingAPI.Interfaces
{
    public interface IAuditLogService
    {
        //3 funtionalities for audit log 
        //We can only perform insert or delete in audit log
        public AuditLog AddAuditLog(AuditLog auditLog);
        public ICollection<AuditLog> GetLog();
        public bool Delete(DateTime date);
    }
}
