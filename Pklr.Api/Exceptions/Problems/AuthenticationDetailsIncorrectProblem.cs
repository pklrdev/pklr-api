using System.Net;

namespace Pklr.Api.Exceptions.Problems;

public class AuthenticationDetailsIncorrectProblem(string detail) : PklrApiProblem
{
    public override ProblemType ProblemType => ProblemType.AuthenticationDetailsIncorrect;
    public override string Title => "Authentication Details Incorrect";
    public override string Detail => detail;
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}