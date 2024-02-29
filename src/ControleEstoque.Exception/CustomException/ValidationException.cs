namespace ControleEstoque.Exception.CustomException;

public class ValidationException : AppException
{
    public ValidationException(List<string> details) : base("Erro de validação")
    {
        Details = details;
        ErrorCode = "400";
    }

    public ValidationException(string message, List<string> details) : base(message)
    {
        Details = details;
        ErrorCode = "400";
    }

    public ValidationException(IEnumerable<string> errors, List<string> details) : base("Erro de validação")
    {
        ErrorCode = "400";
        Details = errors.ToList();
    }

    public List<string> Details { get; set; }
}