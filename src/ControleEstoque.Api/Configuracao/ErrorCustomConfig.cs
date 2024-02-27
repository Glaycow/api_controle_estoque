using ControleEstoque.Api.CustomException;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Configuracao;

public static class ErrorCustomConfig
{
    public static WebApplication AddCustomErrorConfig(this WebApplication app)
    {
        app.UseExceptionHandler(options =>
        {
            options.Run(async context => {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                if (exception != null)
                {
                    var problemDetails = new ProblemDetails
                    {
                        Title = "Ocorreu um erro!",
                        Status = 500
                    };

                    if (exception is AppException appException)
                    {
                        problemDetails.Status = int.Parse(appException.ErrorCode!);
                        problemDetails.Detail = appException.Message;

                        var errorResponse = new ErrorResponse(appException.ErrorCode!, appException.Message);
                        switch (appException)
                        {
                            case NotFoundException:
                                errorResponse.AddDetail("O recurso solicitado não foi encontrado.");
                                break;
                            case BadRequestException:
                                errorResponse.AddDetail("A requisição enviada é inválida. Verifique os dados e tente novamente.");
                                break;
                        }
                
                        if (exception is ValidationException validationException)
                        {
                            errorResponse.Details = validationException.Details;   
                        }

                        context.Response.StatusCode = (int)problemDetails.Status;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsJsonAsync(errorResponse);
                    }
                }
            }); 
        });
        
        return app;
    }
}