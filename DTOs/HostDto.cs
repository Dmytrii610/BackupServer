namespace BackupServer.API.DTOs
{
    public record HostSummaryDto
    {
        public int HostId { get; init; }
        public string HostName { get; init; } = string.Empty;
        public string HostIP { get; init; } = string.Empty;
        public bool IsActive { get; init; }
    }
    public record HostCreateDto
    {
        public int
    }
}