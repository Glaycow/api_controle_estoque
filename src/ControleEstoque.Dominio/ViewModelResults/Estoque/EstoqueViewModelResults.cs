namespace ControleEstoque.Dominio.ViewModelResults.Estoque;

public record EstoqueViewModelResults
{
    public Guid Id { get; set; }
    public decimal SaldoEstoque { get; set; }
    public DateTime MesEstoque { get; set; }
    public Guid ProdutoId { get; set; }
}