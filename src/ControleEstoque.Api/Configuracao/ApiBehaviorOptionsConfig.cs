using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Configuracao;

/// <summary>
///     classe de extensão para configurar a Model invalidas.
/// </summary>
public static class ApiBehaviorOptionsConfig
{
    /// <summary>
    ///     Método de extensão.
    /// </summary>
    public static WebApplicationBuilder AddApplicationBuilder(this WebApplicationBuilder builder)
    {
        // builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

        return builder;
    }
}