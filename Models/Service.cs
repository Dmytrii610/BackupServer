using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(45)]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        public decimal PriceMonthly { get; set; }

        [MaxLength(45)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string BackUpFrequency { get; set; } = "daily";

        [Required]
        public int RetentionDays { get; set; } = 30;

        [Required]
        public bool IncludesIntegrityCheck { get; set; } = false;

        [Required]
        public bool IncludesCompression { get; set; } = true;

        [Required]
        public long DefaultStorageLimitGB { get; set; }

        [Required]
        public int Priority { get; set; } = 0;

        public ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();
    }
}
