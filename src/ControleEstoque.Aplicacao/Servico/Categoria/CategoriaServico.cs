using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Mensagens;

namespace ControleEstoque.Application.Servico.Categoria;

public class CategoriaServico(ICategoriaRepositorio categoriaRepositorio) : ICategoriaServico
{
    private readonly ICategoriaRepositorio _categoriaRepositorio = categoriaRepositorio;

    public void Dispose()
    {
        _categoriaRepositorio.Dispose();
    }

    public async Task<Dominio.Classes.Categoria> AdicionarCategoriaAsync(Dominio.Classes.Categoria categoria)
    {
        return await _categoriaRepositorio.Add(categoria);
    }

    public async Task<Dominio.Classes.Categoria> AlterarCategoriaAsync(Dominio.Classes.Categoria categoria)
    {
        return await _categoriaRepositorio.Update(categoria);
    }

    public async Task ApagarCategoriaAsync(Guid id)
    {
        if (await _categoriaRepositorio.ExisteCategoriaVinculoFornecedorAsync(id))
        {
            throw new ValidationException(MensagensValidacao.CategoriaVinculoFornecedor, []);
        }
        if(await _categoriaRepositorio.ExisteCategoriaVinculoProdutoAsync(id))
        {
            throw new ValidationException(MensagensValidacao.CategoriaVinculoProduto, []);
        }
        await _categoriaRepositorio.Delete(id);
    }
}