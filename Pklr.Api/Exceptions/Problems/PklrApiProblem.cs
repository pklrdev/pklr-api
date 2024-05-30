using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Pklr.Api.Exceptions.Problems;

public abstract class PklrApiProblem
{
    public abstract ProblemType ProblemType { get; }
    public abstract string Title { get; }
    public abstract string Detail { get; }
    public abstract HttpStatusCode StatusCode { get; }

    private ProblemDetails ToProblemDetails()
    {
        return new ProblemDetails
        {
            Type = ProblemType.ToNamespacedString(),
            Title = Title,
            Detail = Detail,
            Status = (int)StatusCode
        };
    }
    
    public IActionResult ToResult()
    {
        var problemDetails = ToProblemDetails();
        
        return new JsonResult(problemDetails)
        {
            StatusCode = (int)StatusCode,
            ContentType = "application/problem+json"
        };
    }

    public override string ToString()
    {
        var problemDetails = ToProblemDetails();
        return JsonSerializer.Serialize(problemDetails);
    }
}