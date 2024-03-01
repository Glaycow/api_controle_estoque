namespace ControleEstoque.Dominio.ViewModelResults.Produto;

public class ProdutoListaViewModelResults
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string NomeFornecedor { get; set; }
    public string NomeCategoria { get; set; }
    public string TipoQuantidade { get; set; }
    public int ValorTipoQuantidade { get; set; }
}