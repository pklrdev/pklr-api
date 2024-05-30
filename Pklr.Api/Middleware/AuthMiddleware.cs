using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Pklr.Api.Domain.Entities;
using Pklr.Api.Exceptions;
using Pklr.Api.Exceptions.Problems;
using Pklr.Api.Integrations.DB;

namespace Pklr.Api.Middleware;

public class AuthMiddleware(RequestDelegate next, IDbClient dbClient)
{
    public const string AuthenticationItem = "authentication";
    
    public async Task InvokeAsync(HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (authHeader == null)
        {
            context.Items.Add(AuthenticationItem, null);
        }
        else
        {
            var parsedHeader = AuthenticationHeaderValue.Parse(authHeader);

            if (parsedHeader.Scheme != "Bearer" || parsedHeader.Parameter == null)
            {
                WriteAuthProblem(context, "Authorization header not in the correct format, needs to use the bearer scheme.");
                return;
            }
            
            var session = await dbClient.GetSession(parsedHeader.Parameter);

            if (session == null)
            {
                WriteAuthProblem(context, "Authorization header referenced a session which doesn't exist.");
                return;
            }
            
            context.Items.Add(AuthenticationItem, session);
        }
        
        await next(context);
    }

    public static Session? GetSession(HttpContext context)
    {
        if (!context.Items.TryGetValue(AuthenticationItem, out var sessionItem))
        {
            throw new InternalErrorException("The HTTP context should contain an authentication item.");
        }
        
        return sessionItem as Session;
    }

    private static void WriteAuthProblem(HttpContext context, string error)
    {
        var problem = new InvalidAuthorizationProblem(error);
                
        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        context.Response.ContentType = "application/problem+json";
        context.Response.Body.Write(Encoding.Unicode.GetBytes(problem.ToString()));
    }
}

public static class AuthMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthMiddleware>();
    }
}