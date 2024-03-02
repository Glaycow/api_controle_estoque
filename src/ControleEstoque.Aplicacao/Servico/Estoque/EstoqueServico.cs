using ControleEstoque.Dominio.Interfaces.Estoque;

namespace ControleEstoque.Application.Servico.Estoque;

public class EstoqueServico(IEstoqueRepositorio estoqueRepositorio) : IEstoqueServico
{
    private readonly  IEstoqueRepositorio _estoqueRepositorio = estoqueRepositorio;

    public void Dispose()
    {
        _estoqueRepositorio.Dispose();
    }

    public async Task<Dominio.Classes.Estoque> CadastrarEntradaAsync(Dominio.Classes.Estoque estoque)
    {
        return await  _estoqueRepositorio.Add(estoque);
    }

    public async Task<Dominio.Classes.Estoque> CadastrarSaidaAsync(Dominio.Classes.Estoque estoque)
    {
        return await _estoqueRepositorio.Update(estoque);
    }
}