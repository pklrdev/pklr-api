namespace Pklr.Api.Integrations.FileStore;

public interface IFileStore
{
    Task<string> GeneratePreSignedUploadUrlForPkgZip(string scope, string packageName, string version);
}