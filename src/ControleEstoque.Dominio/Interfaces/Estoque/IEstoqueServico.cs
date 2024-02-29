namespace ControleEstoque.Dominio.Interfaces.Estoque;

public interface IEstoqueServico : IDisposable
{
    Task<Classes.Estoque> CadastrarEntradaAsync(Classes.Estoque estoque);
    Task<Classes.Estoque> CadastrarSaidaAsync(Classes.Estoque estoque);
}