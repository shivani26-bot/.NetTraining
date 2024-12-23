using Microsoft.EntityFrameworkCore;

namespace AuditLogMicroservice.Contexts
{
    public class AuditContext : DbContext
    {
        public AuditContext(DbContextOptions<AuditContext> options) : base(options)
        {
        }

        public DbSet<AuditLogMicroservice.Models.AuditLog> AuditLogs { get; set; }
    }
}
