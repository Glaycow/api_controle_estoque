using ControleEstoque.Dominio.Classes;

namespace ControleEstoque.Dominio.Interfaces;

public interface ICategoriaServico
{
    Task<Categoria> AdicionarCategoriaAsync(Categoria categoria);
    Task<Categoria> AlterarCategoriaAsync(Categoria categoria);
    Task ApagarCategoriaAsync(Guid id);
}