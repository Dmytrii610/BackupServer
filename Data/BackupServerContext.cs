using BackupServer.API.Models;
using Microsoft.EntityFrameworkCore;
using Host = BackupServer.API.Models.Host;

namespace BackupServer.API.Data
{
    public class BackupServerContext : DbContext
    {
        public BackupServerContext(DbContextOptions<BackupServerContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersRole> Roles { get; set; }
        public DbSet<StorageQuota> Quotas { get; set; }
        public DbSet<ClientService> ClientService { get; set; }
        public DbSet<NotificationSettings> Notifications { get; set; }
        public DbSet<BackUp> BackUps { get; set; }
        public DbSet<BackupSchedule> Schedules { get; set; }
        public DbSet<BackupLogs> BackupLogs { get; set; }
        public DbSet<BackupVersion> BackupVersions { get; set; }
        public DbSet<SumType> SumTypes { get; set; }
        public DbSet<LogLevelType> LogLevels { get; set; }
        public DbSet<ExcludePatterns> ExcludePatterns { get; set; }
        public DbSet<StatusType> Statuses { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BackupVersion>(entity =>
            {
                entity.HasOne(bv => bv.ParentVersion)
                .WithMany(bv => bv.ChildVersions)
                .HasForeignKey(bv => bv.ParentVersionId)
                .OnDelete(DeleteBehavior.SetNull);
            });
        }

    }
}