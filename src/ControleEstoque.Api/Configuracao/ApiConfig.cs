using System.Text.Json;
using ControleEstoque.Api.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Configuracao;

/// <summary>
///     Classe de extensão para configuração da API.
/// </summary>
public static class ApiConfig
{
    /// <summary>
    ///     Método de extensão.
    /// </summary>
    public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        builder.Services
            .AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ConsumesAttribute("application/json"));

                // if you need a specific response type.
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ValidationException), StatusCodes.Status500InternalServerError));
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            })
            .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });


        return builder;
    }
}