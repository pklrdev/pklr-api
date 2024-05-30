namespace Pklr.Api.Domain.Entities;

public class Scope
{
    public string ScopeName { get; set; }
    public AuditPoint Created { get; set; }
    public AuditPoint Updated { get; set; }
    public List<ScopeUser> LinkedUsers { get; set; }

    public static Scope New(string scopeName, UInt64 initialUser)
    {
        var auditPoint = new AuditPoint
        {
            EventTime = DateTime.UtcNow,
            UserId = initialUser
        };
        
        return new Scope
        {
            ScopeName = scopeName,
            Created = auditPoint,
            Updated = auditPoint,
            LinkedUsers = [
                new ScopeUser
                {
                    UserId = initialUser,
                    Role = ScopeRoleTypes.AdminRole
                }
            ]
        };
    }
}