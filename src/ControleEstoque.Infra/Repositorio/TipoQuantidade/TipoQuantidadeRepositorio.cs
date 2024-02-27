using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.TipoQuantidade;

public class TipoQuantidadeRepositorio(DbContext dbContext) : EntityDataService<Dominio.Classes.TipoQuantidade>(dbContext), ITipoQuantidadeRepositorio
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