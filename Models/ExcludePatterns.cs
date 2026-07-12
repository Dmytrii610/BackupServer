using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("ExcludePatterns")]
    public class ExcludePatterns
    {
        [Key]
        public int PatternId { get; set; }
        public int? HostId { get; set; }

        [ForeignKey("HostId")]
        public Host? Host { get; set; }

        [Required]
        [MaxLength(255)]
        public string Pattern { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public bool IsEnabled { get; set; } = true;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
