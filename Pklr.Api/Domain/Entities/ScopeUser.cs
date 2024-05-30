namespace Pklr.Api.Domain.Entities;

public class ScopeUser
{
    public UInt64 UserId { get; set; }
    public ScopeRoleTypes Role { get; set; }
}