using Asp.Versioning;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
// [ApiExplorerSettings(GroupName = "TipoQuantidade")]
public class TipoQuantidadeController : MainController
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Chegou aqui");
    }
}