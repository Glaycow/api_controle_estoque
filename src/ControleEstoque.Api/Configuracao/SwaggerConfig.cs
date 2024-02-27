using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Conventions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ControleEstoque.Api.Configuracao;

public static class SwaggerConfig
{
      /// <summary>
    ///     Método de extensão.
    /// </summary>
    public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
            }).AddMvc(option => { option.Conventions.Add(new VersionByNamespaceConvention()); })
            .AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
                setup.FormatGroupName = (group, version) => $"{group} - {version}";
            });
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // c.IncludeXmlComments(xmlPath);
        });
        builder.Services.ConfigureOptions<NamedSwaggerGenOptions>();

        return builder;
    }

    /// <summary>
    ///     Classe de extensão para configurar o Swagger na apresentação das versões e grupos.
    /// </summary>
    public class NamedSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        : IConfigureNamedOptions<SwaggerGenOptions>
    {
        /// <summary>
        ///     Configuração dos nomes
        /// </summary>
        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        /// <summary>
        ///     Configurando o nome dos grupos.
        /// </summary>
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
        }

        private static OpenApiInfo CreateVersionInfo(
            ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Api lista de compras " + description.GroupName,
                Version = description.ApiVersion.ToString(),
                Description = "Api para gerenciar as listas de compras",
                TermsOfService = new Uri("https://glaycow.shop"),
                Contact = new OpenApiContact
                {
                    Name = "Glaycow Silveira Silva e Souza",
                    Email = "glaycow@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/glaycow-s-silva-e-souza-092706158/")
                }
            };
            if (description.IsDeprecated) info.Description += " This API version has been deprecated.";
            return info;
        }
    }
}