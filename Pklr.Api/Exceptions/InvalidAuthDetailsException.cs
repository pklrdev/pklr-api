using Pklr.Api.Exceptions.Problems;

namespace Pklr.Api.Exceptions;

public class InvalidAuthDetailsException(string message) : PklrException(message)
{
    public override PklrApiProblem ToPklrProblem()
    {
        return new AuthenticationDetailsIncorrectProblem(Message);
    }
}