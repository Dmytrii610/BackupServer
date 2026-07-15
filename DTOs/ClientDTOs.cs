namespace BackupServer.API.DTOs
{
    public record ClientSummaryDto
    {
        public int ClientId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Surname { get; init; }
        public string? ClientTypeName { get; init; }
        public int HostCount { get; init; }
    }
    public record ClientDetailsDto
    {
        public int ClientId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Surname { get; init; }
        public string? ClientTypeName { get; init; }
        public int HostCount { get; init; }
        public string? EmailContact { get; init; }
        public string? PhoneContact { get; init; }
        public string? TaxID { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<HostSummaryDto> Hosts { get; init; } = new List<HostSummaryDto>();
    }
    public record ClientCreateDto
    {
        public string Name { get; init; } = string.Empty;
        public string? Surname { get; init; }
        public int ClientTypeId { get; init; }
        public string EmailContact { get; init; } = string.Empty;
        public string PhoneContact { get; init; } = string.Empty;
        public string? TaxID { get; init; }

    }
}
