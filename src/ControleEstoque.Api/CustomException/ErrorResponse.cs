namespace ControleEstoque.Api.CustomException;

public class ErrorResponse(string errorCode, string message)
{
    public string ErrorCode { get; set; } = errorCode;
    public string Message { get; set; } = message;

    public List<string> Details { get; set; } = [];

    public void AddDetail(string detail)
    {
        Details.Add(detail);
    }
}