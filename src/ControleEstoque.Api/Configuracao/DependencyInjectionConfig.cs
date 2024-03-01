using ControleEstoque.Api.CustomException;
using ControleEstoque.Application.Servico.Categoria;
using ControleEstoque.Application.Servico.Fornecedor;
using ControleEstoque.Application.Servico.TipoQuantidade;
using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.Repositorio.Categoria;
using ControleEstoque.Infra.Repositorio.Fornecedor;
using ControleEstoque.Infra.Repositorio.TipoQuantidade;

namespace ControleEstoque.Api.Configuracao;

public static class DependencyInjectionConfig
{
    public static void ResolveDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddMvc(op => op.Filters.Add(typeof(FiltroExceptions)));
        builder.Services.AddLogging(l =>
        {
            l.AddDebug();
            l.AddConsole();
        });
        
        builder.Services.AddScoped<ControleEstoqueDbContext>();
        
        // repositorio
        builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
        builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        builder.Services.AddScoped<ITipoQuantidadeRepositorio, TipoQuantidadeRepositorio>();
        // servicos
        builder.Services.AddScoped<IFornecedorServico, FornecedorServico>();
        builder.Services.AddScoped<ICategoriaServico, CategoriaServico>();
        builder.Services.AddScoped<ITipoQuantidadeServico, TipoQuantidadeServico>();
    }
}