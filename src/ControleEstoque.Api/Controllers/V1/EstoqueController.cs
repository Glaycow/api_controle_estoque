using Asp.Versioning;
using ControleEstoque.Dominio.Interfaces.Estoque;
using ControleEstoque.Dominio.LancamentoEstoque;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Categoria")]
public class EstoqueController(
    IEstoqueServico estoqueServico,
    IEstoqueRepositorio estoqueRepositorio,
    ILancamentoEstoqueServico lancamentoEstoqueServico,
    ILancamentoEstoqueRepositorio lancamentoEstoqueRepositorio)
    : MainController
{
    private readonly IEstoqueServico _estoqueServico = estoqueServico;
    private readonly IEstoqueRepositorio _estoqueRepositorio = estoqueRepositorio;
    private readonly ILancamentoEstoqueServico _lancamentoEstoqueServico = lancamentoEstoqueServico;
    private readonly ILancamentoEstoqueRepositorio _lancamentoEstoqueRepositorio = lancamentoEstoqueRepositorio;
}