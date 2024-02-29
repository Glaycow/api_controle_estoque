using ControleEstoque.Api.CustomException;
using ControleEstoque.Application.Servico.Fornecedor;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.Repositorio.Fornecedor;

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
        // servicos
        builder.Services.AddScoped<IFornecedorServico, FornecedorServico>();
    }
}