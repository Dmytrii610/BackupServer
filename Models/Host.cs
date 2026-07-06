using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("Host")]
    public class Host
    {
        [Key]
        public int HostId { get; set; }

        [Required]
        [MaxLength(45)]
        public string HostName { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string HostIP { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string SSHUser { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string DestinationPath { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string SourcePath { get; set; } = string.Empty;

        [Required]
        [MaxLength(45)]
        public string OS { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        [Required]
        [Column("client_id")]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
        public int SSHPort { get; set; } = 22;

        [MaxLength(500)]
        public string? SSHKeyPath { get; set; }
        [MaxLength(128)]
        public string? SSHKeyFingerPrint { get; set; }

        public ICollection<BackupSchedule> BackupSchedules { get; set; } = new List<BackupSchedule>();
        public ICollection<BackUp> BackUps { get; set; } = new List<BackUp>();

    }
}
