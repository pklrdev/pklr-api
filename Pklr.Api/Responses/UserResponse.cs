using Pklr.Api.Domain.Entities;

namespace Pklr.Api.Responses;

public class UserResponse
{
    public required UInt64 UserId { get; set; }
    // Email will be null if not current user for privacy concerns
    public string? Email { get; set; }
    public required string DisplayName { get; set; }
    public required bool OnWaitList { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public List<UserScope> LinkedScopes { get; set; } = new List<UserScope>();
}