using ProductMicroservice.Models.DTOs;

namespace ProductMicroservice.Interfaces
{
    public interface IAuditLogService
    {
        public Task<AuditLogDTO> LogAudit(AuditLogDTO auditLog);
    }
}
