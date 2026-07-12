using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("logLevelType")]
    public class LogLevelType
    {
        [Key]
        [Column("idLevelType")]
        public int IdLevelType { get; set; }

        [MaxLength(45)]
        public string? Type { get; set; }

        public ICollection<BackupLogs> BackupLogs { get; set; } = new List<BackupLogs>();
    }
}