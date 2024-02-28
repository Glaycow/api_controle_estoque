namespace ControleEstoque.Dominio.Interfaces.Categoria;

public interface ICategoriaServico
{
    Task<Classes.TipoProduto> AdicionarCategoriaAsync(Classes.TipoProduto tipoProduto);
    Task<Classes.TipoProduto> AlterarCategoriaAsync(Classes.TipoProduto tipoProduto);
    Task ApagarCategoriaAsync(Guid id);
}