using Dapper;
using Pklr.Api.Domain.Entities;

namespace Pklr.Api.Integrations.DB;

public class DbClient(MySqlConnectionBuilder connectionBuilder) : IDbClient
{
    public async Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
        //using (var database = connectionBuilder.Connect())
        //{
        //    return database.QuerySingleAsync<User>("SELECT ")
        //}
    }

    public async Task<User?> GetUserById(UInt64 userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    #region Session
    public Task<Session?> GetSession(string sessionToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateSession(Session session)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSession(string sessionToken)
    {
        throw new NotImplementedException();
    }
    #endregion
}