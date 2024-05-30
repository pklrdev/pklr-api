namespace Pklr.Api.Exceptions;

public class FileStoreException: Exception
{
    public string FileName { get; }
    public FileStoreException(string message, string fileName) : base($"File store error: {message} [{fileName}]")
    {
        FileName = fileName;
    }
}