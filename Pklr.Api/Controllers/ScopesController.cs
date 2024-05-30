using Microsoft.AspNetCore.Mvc;
using Pklr.Api.Responses;

namespace Pklr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScopesController
{
    [HttpGet]
    public async Task<IListResponse<ScopeResponse>> ListScopes()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{scopeId}")]
    public async Task<ScopeResponse> GetScope(string scopeId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ScopeResponse> SaveScope()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{scopeId}")]
    public async Task<> DeleteScope()
    {
        throw new NotImplementedException();
    }
}