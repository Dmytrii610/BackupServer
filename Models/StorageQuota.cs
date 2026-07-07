using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("StorageQuota")]
    public class StorageQuota
    {
        [Key]
        public int QuotaId { get; set; }

        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }

        [Required]
        public int CustomStorageLimitGB { get; set; } = 100;
        public decimal UsedStorageGB { get; set; } = 0M;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}