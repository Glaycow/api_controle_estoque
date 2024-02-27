namespace ControleEstoque.Api.CustomException;

public class AppException : Exception
{
    public string? ErrorCode { get; set; }

    public AppException()
    {
    }

    public AppException(string message) : base(message)
    {
    }

    public AppException(string message, string? errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}