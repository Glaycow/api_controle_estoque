namespace ControleEstoque.Dominio.ViewModelResults.Categoria;

public record CategoriaViewModelResults
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public CategoriaViewModelResults() { }

    public CategoriaViewModelResults(Guid id)
    {
        Id = id;
        Nome = string.Empty;
    }
}