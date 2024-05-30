using Pklr.Api.Exceptions.Problems;

namespace Pklr.Api.Exceptions;

public abstract class PklrException(string message) : Exception(message)
{
    public abstract PklrApiProblem ToPklrProblem();
}