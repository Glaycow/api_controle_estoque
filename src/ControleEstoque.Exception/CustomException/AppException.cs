namespace ControleEstoque.Exception.CustomException;

public class AppException : System.Exception
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