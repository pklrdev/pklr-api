using Pklr.Api.Exceptions.Problems;

namespace Pklr.Api.Exceptions;

public class InternalErrorException(string message) : PklrException(message)
{
    public override PklrApiProblem ToPklrProblem()
    {
        return new InternalErrorProblem(Message);
    }
}