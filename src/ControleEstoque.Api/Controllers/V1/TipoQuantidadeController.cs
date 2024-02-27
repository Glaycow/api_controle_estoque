using Asp.Versioning;
using AutoMapper;
using ControleEstoque.Api.CustomException;
using ControleEstoque.Api.ViewModel.TipoQuantidade;
using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
// [ApiExplorerSettings(GroupName = "TipoQuantidade")]
public class TipoQuantidadeController(ITipoQuantidadeRepositorio tipoQuantidadeRepositorio, ITipoQuantidadeServico tipoQuantidadeServico, IMapper mapper)
    : MainController
{
    private readonly ITipoQuantidadeRepositorio _tipoQuantidadeRepositorio = tipoQuantidadeRepositorio;
    private readonly ITipoQuantidadeServico _tipoQuantidadeServico = tipoQuantidadeServico;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var buscarListaTipoQuantidade = await _tipoQuantidadeRepositorio.ObterListaTipoQuantidadeAsync();
        return Ok(buscarListaTipoQuantidade);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var buscarTipoQuantidade = await _tipoQuantidadeRepositorio.ObterTipoQuantidadePorIdAsync(id);
        return Ok(buscarTipoQuantidade); 
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TipoQuantidadeViewModel tipoQuantidade)
    {
        var salvarTipoQuantidade = await _tipoQuantidadeServico.CadastrarTipoQuantidadeAsync(_mapper.Map<TipoQuantidade>(tipoQuantidade));
        return CreatedAtAction(nameof(Get), new { id = salvarTipoQuantidade.Id }, salvarTipoQuantidade); 
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] TipoQuantidadeViewModel tipoQuantidade)
    {
        var atualizarTipoQuantidade = await _tipoQuantidadeServico.AlterarQuantidadeAsync(_mapper.Map<TipoQuantidade>(tipoQuantidade));
        return Ok(atualizarTipoQuantidade);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tipoQuantidadeServico.ApagarTipoQuantidadeAsync(id);
        return Ok(); 
    }
}