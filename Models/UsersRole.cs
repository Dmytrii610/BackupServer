using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackupServer.API.Models
{
    [Table("usersRole")]
    public class UsersRole
    {
        [Key]
        [Column("idRole")]
        public int RoleId { get; set; }
        [Column("roleType")]
        public string? RoleType { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}