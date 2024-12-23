namespace ProductMicroservice.Models.DTOs
{
    public class AuditLogDTO
    {
        public string TableName { get; set; } = string.Empty;
        public string ColumnName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
