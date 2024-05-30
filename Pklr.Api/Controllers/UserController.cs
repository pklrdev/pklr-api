using Microsoft.AspNetCore.Mvc;
using Pklr.Api.Responses;

namespace Pklr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController
{
    [HttpGet]
    public async Task<IListResponse<UserResponse>> ListUsers()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{scopeId}")]
    public async Task<UserResponse> GetUser(string scopeId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<UserResponse> SaveUser()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{scopeId}")]
    public async Task<IActionResult> DeleteUser()
    {
        throw new NotImplementedException();
    }
}