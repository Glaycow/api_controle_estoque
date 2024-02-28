using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Dominio.Interfaces.Fornecedor;

namespace ControleEstoque.Application.Servico.Fornecedor;

public class FornecedorServico(IFornecedorRepositorio fornecedorRepositorio, ICategoriaRepositorio categoriaRepositorio) : IFornecedorServico
{
    private readonly IFornecedorRepositorio _fornecedorRepositorio = fornecedorRepositorio;
    private readonly ICategoriaRepositorio _categoriaRepositorio = categoriaRepositorio;

    public async Task<Dominio.Classes.Fornecedor> CadastrarFornecedorAsync(Dominio.Classes.Fornecedor fornecedor)
    {
        var novoFornecedor = new Dominio.Classes.Fornecedor
        {
            Id = fornecedor.Id,
            Nome = fornecedor.Nome,
            FornecedorCategoria = []
        };
        foreach (var categoria in fornecedor.FornecedorCategoria)
        {
            var categoriaDb = await _categoriaRepositorio.ObterCategoriaPorIdAsync(categoria.Categoria.Id);
            if (categoriaDb != null)
            {
                novoFornecedor.FornecedorCategoria.Add(new FornecedorCategoria()
                {
                    Categoria = categoriaDb,
                    Fornecedor = fornecedor
                });
            }
        }

        return await _fornecedorRepositorio.Add(novoFornecedor);
    }

    public async Task<Dominio.Classes.Fornecedor> AlterarFornecedorAsync(Dominio.Classes.Fornecedor fornecedor)
    {
        var alterarFornecedor = await _fornecedorRepositorio.GetById(fornecedor.Id);
        alterarFornecedor.Nome = fornecedor.Nome;
        alterarFornecedor.FornecedorCategoria.Clear();
        foreach (var categoria in fornecedor.FornecedorCategoria)
        {
            var categoriaDb = await _categoriaRepositorio.ObterCategoriaPorIdAsync(categoria.Categoria.Id);
            if (categoriaDb != null)
            {
                alterarFornecedor.FornecedorCategoria.Add(new FornecedorCategoria()
                {
                    Categoria = categoriaDb,
                    Fornecedor = alterarFornecedor
                });
            }
        }
        return await _fornecedorRepositorio.Update(alterarFornecedor);
    }

    public async Task ApagarFornecedorAsync(Guid id)
    {
        await _fornecedorRepositorio.Delete(id);
    }

    public void Dispose()
    {
        _fornecedorRepositorio.Dispose();
    }
}