using ControleEstoque.Infra.DbContexts;

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
       
        // servicos
       
        return builder;
    }
}