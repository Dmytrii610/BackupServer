using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("BackUp")]
    public class BackUp
    {
        [Key]
        public int BackupId { get; set; }

        [Required]
        [Column("host_id")]
        public int HostId { get; set; }

        [ForeignKey("HostId")]
        public Host? Host { get; set; }
        
        public long SizeMB { get; set; }

        public int Status { get; set; }

        [ForeignKey("Status")]
        public StatusType? StatusType { get; set; }
        public int DurationSec { get; set; }
        [Column("Timestamp")]
        public DateTime? TimeStamp { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<BackupLogs> BackupLogs { get; set; } = new List<BackupLogs>();
        public ICollection<BackupVersion> BackupVersions { get; set; } = new List<BackupVersion>();

    }
}