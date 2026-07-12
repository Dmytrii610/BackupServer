using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BackupServer.API.Data
{
    public class BackupServerContext : DbContext
    {
        public BackupServerContext(DbContextOptions<BackupServerContext> options) : base(options)
        {

        }
    }
}
