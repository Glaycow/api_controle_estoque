namespace ControleEstoque.Exception.CustomException;

public class NotFoundException : AppException
{
    public NotFoundException(string? mensagem) : base(mensagem ?? "Recurso não encontrado")
    {
        ErrorCode = "404";
    }
}