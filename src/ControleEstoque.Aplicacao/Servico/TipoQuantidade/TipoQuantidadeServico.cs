using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Mensagens;

namespace ControleEstoque.Application.Servico.TipoQuantidade;

public class TipoQuantidadeServico(ITipoQuantidadeRepositorio tipoQuantidadeRepositorio) : ITipoQuantidadeServico
{
    private readonly ITipoQuantidadeRepositorio _tipoQuantidadeRepositorio = tipoQuantidadeRepositorio;

    public void Dispose()
    {
       _tipoQuantidadeRepositorio.Dispose();
    }

    public async Task<TipoQuantidadeViewModelResults> CadastrarTipoQuantidadeAsync(Dominio.Classes.TipoQuantidade tipoQuantidade)
    {
        await _tipoQuantidadeRepositorio.Add(tipoQuantidade);
        
        return new TipoQuantidadeViewModelResults
        {
            Id = tipoQuantidade.Id,
            Descricao = tipoQuantidade.Descricao,
            Quantidade = tipoQuantidade.Quantidade
        };
    }

    public async Task<TipoQuantidadeViewModelResults> AlterarQuantidadeAsync(Dominio.Classes.TipoQuantidade tipoQuantidade)
    {
        await _tipoQuantidadeRepositorio.Update(tipoQuantidade);
        return new TipoQuantidadeViewModelResults
        {
            Id = tipoQuantidade.Id,
            Descricao = tipoQuantidade.Descricao,
            Quantidade = tipoQuantidade.Quantidade
        };
    }

    public async Task ApagarTipoQuantidadeAsync(Guid id)
    {
        if (await _tipoQuantidadeRepositorio.ExisteTipoQuantidadeProdutoAsync(id))
        {
            throw new ValidationException(MensagensValidacao.TipoQuantidadeVinculoProduto, []);
        }

        await _tipoQuantidadeRepositorio.Delete(id);
    }
}