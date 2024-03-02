using ControleEstoque.Dominio.Enum;

namespace ControleEstoque.Dominio.ViewModelResults.LancamentoEstoque;

public record LancamentoEstoqueViewModelResults
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    public TipoLancamento TipoLancamento { get; set; }
    public int Quantidade { get; set; }
    public Guid EstoqueId { get; set; }
    public DateTime DataLancamento { get; set; }
}