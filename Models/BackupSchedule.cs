using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("BackupSchedule")]
    public class BackupSchedule
    {
        [Key]
        public int BackupScheduleId { get; set; }

        [Required]
        public int HostId { get; set; }

        [ForeignKey("HostId")]
        public Host? Host { get; set; }

        [Required]
        [MaxLength(100)]
        public string CronExpression { get; set; } = string.Empty;

        public bool IsEnabled { get; set; } = true;

        public DateTime? NextRunTime { get; set; }

        public DateTime? LastRunTime { get; set; }
    }
}