using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleEstoque.Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/api/[controller]")]
public class MainController : ControllerBase
{

    protected static IEnumerable<string> GerarErrosValidacao(ModelStateDictionary modelState)
    {
        return (from modelStateEntry in modelState.Values from error in modelStateEntry.Errors select error.ErrorMessage).ToList();
    }
}