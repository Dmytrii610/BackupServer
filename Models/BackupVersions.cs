using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{

    public enum VerificationStatus
    {
        Pending,   
        Valid,     
        Corrupted,  
        Failed      
    }

    [Table("BackupVersions")]
    public class BackupVersion
    {
        [Key]
        public int VersionId { get; set; }

        [Required]
        public int BackupId { get; set; }

        [ForeignKey("BackupId")]
        public BackUp? BackUp { get; set; }

        [Required]
        public int VersionNumber { get; set; }

        [MaxLength(500)]
        public string? VersionPath { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public long? SizeMB { get; set; }
        public bool? IsIncremental { get; set; }
        public long? ActualSize { get; set; }
        public long? IncrementalSize { get; set; }
        public int? CheckedSumType { get; set; }

        [ForeignKey("CheckedSumType")]
        public SumType? SumType { get; set; }

        [MaxLength(128)]
        public string? CheckedSumValue { get; set; }

        public DateTime? VerifiedAt { get; set; }

        
        public VerificationStatus? VerificationStatus { get; set; }
        public int? ParentVersionId { get; set; }

        [ForeignKey("ParentVersionId")]
        public BackupVersion? ParentVersion { get; set; }
        public ICollection<BackupVersion> ChildVersions { get; set; } = new List<BackupVersion>();
    }
}