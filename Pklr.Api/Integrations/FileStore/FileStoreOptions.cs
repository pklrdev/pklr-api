namespace Pklr.Api.Integrations.FileStore;

public class FileStoreOptions
{
    public string BucketName { get; set; }
    public FileStoreType Type { get; set; }
}

public enum FileStoreType
{
    LocalFileStore,
    S3FileStore
}