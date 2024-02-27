namespace ControleEstoque.Api.CustomException;

public class NotFoundException : AppException
{
    public NotFoundException() : base("Recurso não encontrado")
    {
        ErrorCode = "404";
    }
}