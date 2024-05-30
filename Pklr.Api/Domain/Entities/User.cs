namespace Pklr.Api.Domain.Entities;

public class User
{
    public required UInt64 UserId { get; set; }
    public required string Email { get; set; }
    public required string EncodedPassword { get; set; }
    public required string DisplayName { get; set; }
    public required bool OnWaitList { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public List<UserScope> LinkedScopes { get; set; } = new List<UserScope>();

    public static User New(string email, string encodedPassword, string displayName)
    {
        var now = DateTime.UtcNow;

        return new User
        {
            // User Id will be overriden by the DB
            UserId = 0,
            Email = email,
            EncodedPassword = encodedPassword,
            DisplayName = displayName,
            OnWaitList = true,
            CreatedAt = now,
            UpdatedAt = now
        };
    }
}