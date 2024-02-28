namespace ControleEstoque.Dominio.Model;

public record FornecedorViewModel
{
    public Guid Id;
    public string Nome;
    public List<CategoriaViewModel> Categoria;
}