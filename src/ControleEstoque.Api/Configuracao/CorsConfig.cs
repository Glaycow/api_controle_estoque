namespace ControleEstoque.Api.Configuracao;

/// <summary>
///     Classe de extensão para configurar o CORS da aplicação.
/// </summary>
public static class CorsConfig
{
    /// <summary>
    ///     Método de extensão.
    /// </summary>
    public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Development", corsPolicyBuilder =>
                corsPolicyBuilder
                    .WithOrigins("https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((x) => true)
                    .AllowCredentials());
        });

        return builder;
    }
}