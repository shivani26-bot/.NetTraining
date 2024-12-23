using System.ComponentModel.DataAnnotations;

namespace AuditLogMicroservice.Models
{
    public class AuditLog : IEquatable<AuditLog>
    {
        [Key]
        public int LogId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string ColumnName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
        public bool Equals(AuditLog? other)
        {
            if (other == null) return false;
            return LogId == other.LogId;
        }
    }
}


