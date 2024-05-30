using Microsoft.AspNetCore.Identity;
using Pklr.Api.Domain.Entities;
using Pklr.Api.Exceptions;
using Pklr.Api.Integrations.DB;

namespace Pklr.Api.Domain.Logic;

public class UserLogic
{
    private readonly IDbClient _dbClient;
    private readonly PasswordHasher<User> _passwordHasher;
    
    public UserLogic(IDbClient dbClient)
    {
        _dbClient = dbClient;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<Session> Authenticate(string? email, string? password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new InvalidAuthDetailsException(
                "Either the email or password were not provided. Both fields are required.");
        }
        
        var user = await _dbClient.GetUserByEmail(email);

        if (user == null)
        {
            throw new InvalidAuthDetailsException(
                "Either the email or password is incorrect, check the details provided and try again.");
        }

        var passwordCheckResult = await CheckPassword(user, password);

        if (!passwordCheckResult)
        {
            throw new InvalidAuthDetailsException(
                "Either the email or password is incorrect, check the details provided and try again.");
        }

        var session = Session.New(user.UserId);
        await _dbClient.CreateSession(session);

        return session;
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        var testResult = _passwordHasher.VerifyHashedPassword(user, user.EncodedPassword, password);

        if (testResult == PasswordVerificationResult.Failed)
        {
            return false;
        }

        if (testResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            user.EncodedPassword = _passwordHasher.HashPassword(user, password);
            user.UpdatedAt = DateTime.UtcNow;
            await _dbClient.UpdateUser(user);
        }

        return true;
    }

    public async Task DestroySession(string sessionToken)
    {
        await _dbClient.DeleteSession(sessionToken);
    }
}