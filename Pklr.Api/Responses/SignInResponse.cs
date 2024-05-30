namespace Pklr.Api.Responses;

public class SignInResponse
{
    public required string AuthenticationToken { get; set; }
    public required UInt64 UserId { get; set; }
}