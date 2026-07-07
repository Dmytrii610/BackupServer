using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("statusType")]
    public class StatusType
    {
        [Key]
        [Column("idstatusType")]
        public int IdStatusType { get; set; }
        [Column("statusType")]
        public string? StatusTypeName { get; set; }
        public ICollection<BackUp> BackUps { get; set; } = new List<BackUp>();
    }
}