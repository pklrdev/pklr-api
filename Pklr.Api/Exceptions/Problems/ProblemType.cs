using System.Text;
using Microsoft.Extensions.Primitives;

namespace Pklr.Api.Exceptions.Problems;

public enum ProblemType
{
    AuthenticationDetailsIncorrect,
    InvalidAuthorization,
    InternalError,
}

public static class ProblemTypeExtensions
{
    private const string ProblemNamespace = "https://api.pklr.dev/problems/";

    private static string ToKebabCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var builder = new StringBuilder(input.Length * 2);

        for (var i = 0; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                if (i != 0)
                {
                    builder.Append('-');
                }

                builder.Append(char.ToLower(input[i]));
            }
            else
            {
                builder.Append(input[i]);
            }
        }

        return builder.ToString();
    }
    
    public static string ToNamespacedString(this ProblemType problemType)
    {
        var problemCode = ToKebabCase(problemType.ToString());
        return $"{ProblemNamespace}{problemCode}";
    }
}