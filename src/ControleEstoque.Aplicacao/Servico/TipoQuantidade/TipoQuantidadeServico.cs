using ControleEstoque.Dominio.Interfaces.TipoQuantidade;

namespace ControleEstoque.Application.Servico.TipoQuantidade;

public class TipoQuantidadeServico(ITipoQuantidadeRepositorio tipoQuantidadeRepositorio) : ITipoQuantidadeServico
{
    private readonly ITipoQuantidadeRepositorio _tipoQuantidadeRepositorio = tipoQuantidadeRepositorio;

    public async Task<Dominio.Classes.TipoQuantidade> CadastrarTipoQuantidadeAsync(Dominio.Classes.TipoQuantidade tipoQuantidade)
    {
       return await _tipoQuantidadeRepositorio.Add(tipoQuantidade);
    }

    public async Task<Dominio.Classes.TipoQuantidade> AlterarQuantidadeAsync(Dominio.Classes.TipoQuantidade tipoQuantidade)
    {
        return await _tipoQuantidadeRepositorio.Update(tipoQuantidade);
    }

    public async Task ApagarTipoQuantidadeAsync(Guid id)
    {
       await _tipoQuantidadeRepositorio.Delete(id);
    }

    public void Dispose()
    {
        _tipoQuantidadeRepositorio.Dispose();
    }
}