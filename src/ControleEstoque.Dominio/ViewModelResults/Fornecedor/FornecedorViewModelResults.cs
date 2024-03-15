using ControleEstoque.Dominio.ViewModelResults.Categoria;

namespace ControleEstoque.Dominio.ViewModelResults.Fornecedor;

public record FornecedorViewModelResults
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public List<CategoriaViewModelResults> Categorias { get; set; }

    public FornecedorViewModelResults() { }

    public FornecedorViewModelResults(Guid id)
    {
        Id = id;
        Categorias = new List<CategoriaViewModelResults>(); 
        Nome = string.Empty;
    }
}