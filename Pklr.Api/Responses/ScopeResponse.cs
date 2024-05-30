using Pklr.Api.Domain;
using Pklr.Api.Domain.Entities;

namespace Pklr.Api.Responses;

public class ScopeResponse
{
    public required string ScopeName { get; set; }
    public required AuditPoint Created { get; set; }
    public required AuditPoint Updated { get; set; }
    public required List<ScopeUser> LinkedUsers { get; set; }
}