using ControleEstoque.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Api.Configuracao;

public static class DbContextConfig
{
    public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ControleEstoqueDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString"));
        });

        return builder; 
    }
}