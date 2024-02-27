namespace ControleEstoque.Api.CustomException;

public class BadRequestException : AppException
{
    public BadRequestException() : base("Requisição inválida")
    {
        ErrorCode = "400";
    }
}