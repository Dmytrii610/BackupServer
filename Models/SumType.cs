using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("sumType")]
    public class SumType
    {
        [Key]
        [Column("idsumType")]
        public int SumTypeId { get; set; }
        public string? Type { get; set; }
        public ICollection<BackupVersion> BackupVersions { get; set; } = new List<BackupVersion>();
    }
}