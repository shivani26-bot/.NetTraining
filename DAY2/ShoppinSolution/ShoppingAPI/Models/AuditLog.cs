using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models
{

    //Its a record of all the action and event performed within application 
    public class AuditLog : IEquatable<AuditLog>
    {

        [Key] //indicates that LogId is primary key
        public int LogId { get; set; }
        //public int Id { get; set; }
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
