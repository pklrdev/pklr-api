using Pklr.Api.Domain.Logic;

namespace Pklr.Api.Domain.Entities;

public class Session
{
    private static readonly TimeSpan DefaultDuration = TimeSpan.FromMinutes(60);
    
    public required string SessionToken { get; set; }
    public required UInt64 UserId { get; set; }
    public required DateTime Expires { get; set; }

    public static Session New(UInt64 userId)
    {
        return new Session
        {
            SessionToken = TokenGenerator.NewToken(),
            UserId = userId,
            Expires = DateTime.UtcNow.Add(DefaultDuration)
        };
    }
}