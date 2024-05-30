using System.Net;

namespace Pklr.Api.Exceptions.Problems;

public class InvalidAuthorizationProblem(string detail) : PklrApiProblem
{
    public override ProblemType ProblemType => ProblemType.InvalidAuthorization;
    public override string Title => "Invalid Authorization";
    public override string Detail => detail;
    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
}