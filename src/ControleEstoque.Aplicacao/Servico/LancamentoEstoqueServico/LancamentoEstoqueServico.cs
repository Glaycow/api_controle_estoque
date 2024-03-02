using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.Estoque;
using ControleEstoque.Dominio.LancamentoEstoque;

namespace ControleEstoque.Application.Servico.LancamentoEstoqueServico;

public class LancamentoEstoqueServico(
    ILancamentoEstoqueRepositorio lancamentoEstoqueRepositorio,
    IEstoqueRepositorio estoqueRepositorio,
    IEstoqueGerenciamentoRepositorio estoqueGerenciamentoRepositorio,
    ILancamentoEstoqueGerenciarRepositorio estoqueGerenciarRepositorio) : ILancamentoEstoqueServico
{
    public ILancamentoEstoqueRepositorio LancamentoEstoqueRepositorio { get; } = lancamentoEstoqueRepositorio;

    private readonly ILancamentoEstoqueGerenciarRepositorio _lancamentoEstoqueGerenciar = estoqueGerenciarRepositorio;
    private readonly IEstoqueGerenciamentoRepositorio _estoqueGerenciamentoRepositorio = estoqueGerenciamentoRepositorio;

    public void Dispose()
    {
        _lancamentoEstoqueGerenciar.Dispose();
        _estoqueGerenciamentoRepositorio.Dispose();
    }

    public async Task<Guid> AdicionarLancamentoEstoqueAsync(LancamentoEstoque lancamentoEstoque)
    {
        var validarEstoqueMes = await _estoqueGerenciamentoRepositorio.ValidarEstoqueMesAsync(lancamentoEstoque.ProdutoId, lancamentoEstoque.DataLancamento);
        if (validarEstoqueMes)
        {
            await _lancamentoEstoqueGerenciar.CadastrarLancamentoEstoqueComEstoqueDisponivelAsync(lancamentoEstoque);
            return lancamentoEstoque.Id;
        }

        await _lancamentoEstoqueGerenciar.CadastrarLancamentoEstoqueSemEstoqueDisponivelAsync(lancamentoEstoque);
        return lancamentoEstoque.Id;
    }

    public async Task<Guid> AlterarLancamentoEstoqueAsync(LancamentoEstoque lancamentoEstoque)
    {
        await _lancamentoEstoqueGerenciar.AlterarLancamentoEstoqueAsync(lancamentoEstoque);
        return lancamentoEstoque.Id;
    }

    public async Task ApagarLancamentoEstoqueAsync(Guid idLancamentoEstoque)
    {
        await _lancamentoEstoqueGerenciar.ExcluirLancamentoEstoqueAsync(idLancamentoEstoque);
    }
}