using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;

namespace ControleEstoque.Application.Servico.Fornecedor;

public class FornecedorServico(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Fornecedor>(dbContext), IFornecedorServico
{
    public async Task<FornecedorViewModelResults> CadastrarFornecedorAsync(Dominio.Classes.Fornecedor fornecedor)
    {
        try
        {
            await Db.FornecedorCategoria.AddRangeAsync(fornecedor.Categorias);
            DbSet.Add(fornecedor);
            await Db.SaveChangesAsync();
            return fornecedor.Converter();
        }
        catch (System.Exception e)
        { 
            throw new BadRequestException(e.Message);
        }
    }

    public Task<FornecedorViewModelResults> AlterarFornecedorAsync(Dominio.Classes.Fornecedor fornecedor)
    {
        throw new NotImplementedException();
    }

    public Task ApagarFornecedorAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}