using System.Security.Cryptography;

namespace Pklr.Api.Domain.Logic;

public class TokenGenerator
{
    private const int TokenLength = 100;
    private const string PossibleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
    
    public static string NewToken()
    {
        return RandomNumberGenerator.GetString(PossibleChars, TokenLength);
    }
}