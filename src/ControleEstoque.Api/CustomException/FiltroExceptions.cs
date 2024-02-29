using System.Net;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Mensagens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControleEstoque.Api.CustomException;

public class FiltroExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case ValidationException:
                LancarErrorValidacao(context);
                break;
            case NotFoundException:
                LancarErrorNotFound(context);
                break;
            case BadRequestException:
                LancarErrorBadException(context);
                break;
            default:
                LancarErrorDesconhecido(context);
                break;
        }
    }

    private static void LancarErrorValidacao(ExceptionContext context)
    {
        var erroDeValidacao = context.Exception as ValidationException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableContent;
        var errorResponse = new ErrorResponse(HttpStatusCode.UnprocessableContent.ToString(), erroDeValidacao!.Message);
        context.Result = new ObjectResult(errorResponse);
    }

    private static void LancarErrorNotFound(ExceptionContext context)
    {
        var erroDeValidacao = context.Exception as NotFoundException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        var errorResponse = new ErrorResponse(HttpStatusCode.NotFound.ToString(), erroDeValidacao!.Message);
        context.Result = new ObjectResult(errorResponse);
    }
    
    private static void LancarErrorBadException(ExceptionContext context)
    {
        var erroDeValidacao = context.Exception as BadRequestException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        var errorResponse = new ErrorResponse(HttpStatusCode.BadRequest.ToString(), erroDeValidacao!.Message);
        context.Result = new ObjectResult(errorResponse);
    }

    private static void LancarErrorDesconhecido(ExceptionContext context)
    {
        var errorResponse = new ErrorResponse("500", MensagensValidacao.ErrorDesconhecido);
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}