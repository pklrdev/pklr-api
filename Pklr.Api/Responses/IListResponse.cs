namespace Pklr.Api.Responses;

public interface IListResponse<T>
{
    public List<T> Data { get; set; }
    public UInt64 Offset { get; set; }
}