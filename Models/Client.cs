using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [Column("client_type")]
        public int ClientTypeId { get; set; }

        [ForeignKey("ClientTypeId")]
        public ClientType? ClientType { get; set; }
        
        public ICollection<Host> Hosts { get; set; } = new List<Host>();
        public ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

        public StorageQuota? StorageQuota { get; set; }
        public NotificationSettings? NotificationSettings { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(45)]
        public string? Surname { get; set; }
        public string? EmailContact { get; set; }
        public string? PhoneContact { get; set; }
        public string? TaxID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
