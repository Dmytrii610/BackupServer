using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models;

[Table("clientType")]
public class ClientType
{
    [Key]
    [Column("id_type")]
    public int IdType { get; set; }

    [Required]
    [MaxLength(45)]
    public string Type { get; set; } = string.Empty;
    public ICollection<Client> Clients { get; set; } = new List<Client>();
}