using ControleEstoque.Dominio.Classes;
using ControleEstoque.Infra.DbContexts;

namespace ControleEstoque.Api.Configuracao;

/// <summary>
///     Classe de extensão para iniciar o banco de dados.
/// </summary>
public static class DmMigrationHelperExtension
{
    /// <summary>
    ///     Método de extensão.
    /// </summary>
    public static void UseDbMigrationHelper(this WebApplication app)
    {
        DbMigrationHelpers.EnsureSeedData(app).Wait();
    }
}

public static class DbMigrationHelpers
{
    /// <summary>
    ///     Método de extensão.
    /// </summary>
    public static async Task EnsureSeedData(WebApplication serviceScope)
    {
        var service = serviceScope.Services.CreateScope().ServiceProvider;
        await PreencherBanco(service);
    }

    private static async Task PreencherBanco(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        var context = scope.ServiceProvider.GetRequiredService<ControleEstoqueDbContext>();
        await CadastrarTipoQuantidade(context);
    }

    private static async Task CadastrarTipoQuantidade(ControleEstoqueDbContext context)
    {
        if (context.TipoQuantidades.Any()) return;

        await context.TipoQuantidades.AddRangeAsync([
            new TipoQuantidade { Descricao = "Unidade", Quantidade = 1 },
            new TipoQuantidade { Descricao = "Engradado de cerveja 600ml", Quantidade = 24 },
            new TipoQuantidade { Descricao = "Engradado de cerveja 300ml", Quantidade = 24 },
            new TipoQuantidade { Descricao = "Engradado Refrigerante 2L", Quantidade = 6 },
            new TipoQuantidade { Descricao = "Engradado Refrigerante 600ml", Quantidade = 12 },
            new TipoQuantidade { Descricao = "Engradado Refrigerante Lata", Quantidade = 12 },
            new TipoQuantidade { Descricao = "Fardo Embalagem", Quantidade = 100 },
        ]);
        await context.SaveChangesAsync();
    }

    private static async Task CadastrarTipoProduto(ControleEstoqueDbContext context)
    {
        if (context.Categorias.Any()) return;

        await context.Categorias.AddRangeAsync([
            new Categoria { Nome = "Bebida Alcoolica" },
            new Categoria { Nome = "Refrigerante" },
            new Categoria { Nome = "Embalagem" },
        ]);
        await context.SaveChangesAsync();
    }
}