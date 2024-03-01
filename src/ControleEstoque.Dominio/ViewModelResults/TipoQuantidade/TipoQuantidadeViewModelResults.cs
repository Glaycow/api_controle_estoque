namespace ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;

public record TipoQuantidadeViewModelResults
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}