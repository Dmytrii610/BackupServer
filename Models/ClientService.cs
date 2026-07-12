using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("ClientService")]
    public class ClientService
    {
        [Key]
        public int ClientServiceId { get; set; }

        [Required]
        [Column("client_id")]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }

        [Required]
        [Column("service_id")]
        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsEnabled { get; set; } = true;

        [MaxLength(100)]
        public string? CustomSchedule { get; set; }
    }
}