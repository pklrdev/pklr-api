using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Pklr.Api.Exceptions;

namespace Pklr.Api.Integrations.FileStore;

public class FileStore : IFileStore
{
    private IAmazonS3 _s3;
    private readonly FileStoreOptions _options;

    public FileStore(FileStoreOptions options)
    {
        _s3 = new AmazonS3Client();
        _options = options;
    }

    public async Task<string> GeneratePreSignedUploadUrlForPkgZip(string scope, string packageName, string version)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = _options.BucketName,
            Key = $"{scope}/{packageName}/{version}/{packageName}@{version}.zip",
            Verb = HttpVerb.PUT,
            Expires = DateTime.UtcNow.AddHours(1),
            ContentType = "application/zip",
        };

        return await _s3.GetPreSignedURLAsync(request);
    }
}