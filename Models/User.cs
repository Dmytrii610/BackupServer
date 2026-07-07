using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Id")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string PsswdHash { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [Column("Role")]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UsersRole? UsersRole { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        
        public DateTime? LastLogin { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? LastLoginIP { get; set; }
    }
}
