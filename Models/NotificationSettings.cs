using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("NotificationSettings")]
    public class NotificationSettings
    {
        [Key]
        public int NotificationSettingsId { get; set; }

        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        public bool NotificationOnSuccess { get; set; } = true;
        public bool NotifyOnFailure { get; set; } = false;
        public bool NotifyOnWarning { get; set; } = false;
    }
}