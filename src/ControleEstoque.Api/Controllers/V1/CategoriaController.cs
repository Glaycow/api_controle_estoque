using Asp.Versioning;
using AutoMapper;
using ControleEstoque.Api.CustomException;
using ControleEstoque.Api.ViewModel.Categoria;
using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Mensagens;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Categoria")]
public class CategoriaController(IMapper mapper, ICategoriaRepositorio categoriaRepositorio, ICategoriaServico categoriaServico)
    : MainController
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoriaRepositorio _categoriaRepositorio = categoriaRepositorio;
    private readonly ICategoriaServico _categoriaServico = categoriaServico;

    [HttpGet]
    [ProducesResponseType(typeof(List<Categoria>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var categorias = await _categoriaRepositorio.ObterListaCategoriaAsync();
        return Ok(categorias);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var categoria = await _categoriaRepositorio.ObterListaCategoriaPorIdAsync(id);
        return Ok(categoria);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CadastroCategoriaViewModel categoria)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        
        var categoriaCriada = await _categoriaServico.AdicionarCategoriaAsync(_mapper.Map<Categoria>(categoria));
        return CreatedAtAction(nameof(Get), new { id = categoriaCriada.Id }, categoriaCriada);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(Guid id, [FromBody] AlterarCategoriaViewModel categoria)
    {
        if (id != categoria.Id)
        {
            ModelState.AddModelError("Id", MensagensValidacao.IdInvalido);
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var categoriaAtualizada = await _categoriaServico.AlterarCategoriaAsync(_mapper.Map<Categoria>(categoria));
        return Ok(categoriaAtualizada);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoriaServico.ApagarCategoriaAsync(id);
        return Ok();
    }
}