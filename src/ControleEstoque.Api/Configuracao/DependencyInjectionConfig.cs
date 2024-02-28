using ControleEstoque.Application.Servico.Categoria;
using ControleEstoque.Application.Servico.Fornecedor;
using ControleEstoque.Application.Servico.TipoQuantidade;
using ControleEstoque.Dominio.Interfaces;
using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using ControleEstoque.Infra.Repositorio.Fornecedor;
using ControleEstoque.Infra.Repositorio.TipoQuantidade;
using CategoriaRepositorio = ControleEstoque.Infra.Repositorio.Categoria.CategoriaRepositorio;

namespace ControleEstoque.Api.Configuracao;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddLogging(l =>
        {
            l.AddDebug();
            l.AddConsole();
        });
        
        builder.Services.AddScoped<ControleEstoqueDbContext>();
        
        // repositorio
        builder.Services.AddScoped<ITipoQuantidadeRepositorio, TipoQuantidadeRepositorio>();
        builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
        // servicos
        builder.Services.AddScoped<ITipoQuantidadeServico, TipoQuantidadeServico>();
        builder.Services.AddScoped<ICategoriaServico, CategoriaServico>();
        builder.Services.AddScoped<IFornecedorServico, FornecedorServico>();
        return builder;
    }
}