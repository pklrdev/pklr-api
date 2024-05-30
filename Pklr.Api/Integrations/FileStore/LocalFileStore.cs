using Pklr.Api.Exceptions;

namespace Pklr.Api.Integrations.FileStore;

public class LocalFileStore : IFileStore
{
    private const string FixedResultBaseUrl = "http://localhost:12321/";

    public async Task<string> GeneratePreSignedUploadUrlForPkgZip(string scope, string packageName, string version)
    {
        return await Task.FromResult($"{FixedResultBaseUrl}{Guid.NewGuid()}");
    }
}