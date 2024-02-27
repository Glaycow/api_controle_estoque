using Asp.Versioning.ApiExplorer;
using ControleEstoque.Api.Configuracao;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddSwaggerConfig()
    .AddApiConfig()
    .AddDbContextConfig();

var app = builder.Build();

app.AddCustomErrorConfig();

var providerSwagger = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        foreach (var description in providerSwagger.ApiVersionDescriptions.OrderBy(t => t.GroupName))
            o.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
