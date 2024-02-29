using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using ControleEstoque.Mensagens;
using Microsoft.EntityFrameworkCore;

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

    public async Task<FornecedorViewModelResults> AlterarFornecedorAsync(Dominio.Classes.Fornecedor fornecedor)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var buscarFornecedor = await BuscarFornecedorCategoriaPorIdAsync(fornecedor.Id);
            if (buscarFornecedor == null)
            {
                throw new ValidationException(MensagensValidacao.ForneceNaoEncontado, []);
            }

            buscarFornecedor.Nome = fornecedor.Nome;
            // Remove as categorias que não estão mais presentes no fornecedor atualizado
            foreach (var categoriaExistente in fornecedor.Categorias.Where(categoriaExistente => !buscarFornecedor.Categorias.Contains(categoriaExistente)))
            {
                // todo depois fazer uma validação para não deixar remover uma categoria de um fornecedor que já tenha um produto da mesma.
                var buscarCategoriaRemovida = await Db.FornecedorCategoria
                    .Where(fc => fc.CategoriaId == categoriaExistente.CategoriaId && fc.FornecedorId == categoriaExistente.FornecedorId)
                    .FirstOrDefaultAsync();
                if (buscarCategoriaRemovida != null)
                {
                    Db.FornecedorCategoria.Remove(buscarCategoriaRemovida);
                }
            }
            // Adiciona novas categorias ao fornecedor
            foreach (var categoriaId in fornecedor.Categorias.Where(categoriaId => buscarFornecedor.Categorias.All(fc => fc.CategoriaId != categoriaId.CategoriaId)))
            {
                var categoriaFornecedor = new FornecedorCategoria
                {
                    FornecedorId = fornecedor.Id,
                    CategoriaId = categoriaId.CategoriaId
                };
                buscarFornecedor.Categorias.Add(categoriaFornecedor);
                await Db.FornecedorCategoria.AddAsync(categoriaFornecedor);
            }

            Db.Update(buscarFornecedor);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
            return fornecedor.Converter();
        }
        catch (System.Exception e)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(e.Message);
        }
    }

    public Task ApagarFornecedorAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    private async Task<Dominio.Classes.Fornecedor> BuscarFornecedorCategoriaPorIdAsync(Guid id)
    {
        return await DbSet
            .Include(c => c.Categorias)
            .Where(f => f.Id == id)
            .FirstAsync();
    }
}