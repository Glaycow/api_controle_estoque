namespace ControleEstoque.Dominio.Interfaces.Categoria;

public interface ICategoriaServico
{
    Task<Classes.Categoria> AdicionarCategoriaAsync(Classes.Categoria categoria);
    Task<Classes.Categoria> AlterarCategoriaAsync(Classes.Categoria categoria);
    Task ApagarCategoriaAsync(Guid id);
}