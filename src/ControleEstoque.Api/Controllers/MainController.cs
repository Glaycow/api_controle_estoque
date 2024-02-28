using ControleEstoque.Api.CustomException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleEstoque.Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/api/[controller]")]
public class MainController : ControllerBase
{

    protected static ErrorResponse GerarErrosValidacao(ModelStateDictionary modelState)
    {
        var errorResponse = new ErrorResponse("400", "");
        foreach (var item in modelState.Values)
        {
            errorResponse.AddDetail(item.Errors[0].ErrorMessage);
        }
        return errorResponse;
    }
}