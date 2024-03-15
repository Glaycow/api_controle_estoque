namespace ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;

public record TipoQuantidadeViewModelResults
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }

    public TipoQuantidadeViewModelResults() { }

    public TipoQuantidadeViewModelResults(Guid id)
    {
        Id = id;
        Descricao = string.Empty;
        Quantidade = 0;
    }
}