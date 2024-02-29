namespace ControleEstoque.Exception.CustomException;

public class BadRequestException : AppException
{
    public BadRequestException(string? mensagem) : base(mensagem ?? "Requisição inválida")
    {
        ErrorCode = "400";
    }
}