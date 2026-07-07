using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("BackupLog")]
    public class BackupLogs
    {
        [Key]
        public int BackupLogId { get; set; }
        [Required]
        public int BackupId { get; set; }
        [ForeignKey("BackupId")]
        public BackUp? BackUp { get; set; }
        [Required]
        [Column("Timestamp")]
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        [Column("LogLevel")]
        public int LogLevelId { get; set; }
        [ForeignKey("LogLevelId")]
        public LogLevelType? LogType { get; set; }
        public string? Message { get; set; }
        [MaxLength(50)]
        public string? Source { get; set; }

    }
}