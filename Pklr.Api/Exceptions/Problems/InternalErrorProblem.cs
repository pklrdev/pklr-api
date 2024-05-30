using System.Net;

namespace Pklr.Api.Exceptions.Problems;

public class InternalErrorProblem(string detail) : PklrApiProblem
{
    public override ProblemType ProblemType => ProblemType.InternalError;
    public override string Title => "Internal Error";
    public override string Detail => detail;
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}