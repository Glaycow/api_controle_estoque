using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;

namespace ControleEstoque.Infra.Repositorio.TipoQuantidade;

public class TipoQuantidadeRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.TipoQuantidade>(dbContext), ITipoQuantidadeRepositorio
{
    public async Task<IEnumerable<Dominio.Classes.TipoQuantidade>> ObterListaTipoQuantidadeAsync()
    {
        return await GetAll();
    }

    public async Task<Dominio.Classes.TipoQuantidade> ObterTipoQuantidadePorIdAsync(Guid id)
    {
        return await GetById(id);
    }
}