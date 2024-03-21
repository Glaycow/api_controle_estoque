namespace ControleEstoque.Dominio.ViewModelResults.Estoque;

public record DashboardMes
{
    public decimal ValorEntrada { get; set; }
    public decimal ValorSaida { get; set; }
}