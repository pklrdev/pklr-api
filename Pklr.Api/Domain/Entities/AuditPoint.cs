namespace Pklr.Api.Domain.Entities;

public class AuditPoint
{
    public DateTime EventTime { get; set; }
    public UInt64 UserId { get; set; }
}