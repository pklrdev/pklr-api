using Microsoft.AspNetCore.Mvc;
using Pklr.Api.Domain.Logic;
using Pklr.Api.Exceptions;
using Pklr.Api.Middleware;
using Pklr.Api.Requests;

namespace Pklr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(UserLogic userLogic) : ControllerBase
{
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        try
        {
            
            var session = await userLogic.Authenticate(request.Email, request.Password);
            return new OkObjectResult(session);
        }
        catch (PklrException ex)
        {
            return ex.ToPklrProblem().ToResult();
        }
    }
    
    [HttpPost("signout")]
    public async Task<IActionResult> StopSession()
    {
        try
        {
            var session = AuthMiddleware.GetSession(HttpContext);

            if (session != null)
            {
                await userLogic.DestroySession(session.SessionToken);
            }
            
            return new OkResult();
        }
        catch (PklrException ex)
        {
            return ex.ToPklrProblem().ToResult();
        }
    }
}