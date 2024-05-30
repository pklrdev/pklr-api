using Pklr.Api.Domain.Logic;

namespace Pklr.Api.Domain.Entities;

public class PendingUser
{
    public required string Email { get; set; }
    public required string EncodedPassword { get; set; }
    public required string DisplayName { get; set; }
    public required string VerificationToken { get; set; }
    public required DateTime CreatedAt { get; set; }

    public static PendingUser New(string email, string encodedPassword, string displayName)
    {
        return new PendingUser
        {
            Email = email,
            EncodedPassword = encodedPassword,
            DisplayName = displayName,
            VerificationToken = TokenGenerator.NewToken(),
            CreatedAt = DateTime.UtcNow
        };
    }
}