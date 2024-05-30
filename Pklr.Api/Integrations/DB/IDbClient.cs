using Pklr.Api.Domain.Entities;

namespace Pklr.Api.Integrations.DB;

public interface IDbClient
{
    #region User 
    public Task<User?> GetUserByEmail(string email);
    public Task<User?> GetUserById(UInt64 userId);
    public Task UpdateUser(User user);
    #endregion
    
    #region Session
    public Task<Session?> GetSession(string sessionToken);
    public Task CreateSession(Session session);
    public Task DeleteSession(string sessionToken);
    #endregion

    #region Scope
    
    #endregion
    
    #region Package
    
    #endregion
    
    #region PackageVersion
    
    #endregion
}