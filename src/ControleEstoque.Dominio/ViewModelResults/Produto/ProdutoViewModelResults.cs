using ControleEstoque.Dominio.ViewModelResults.Categoria;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;

namespace ControleEstoque.Dominio.ViewModelResults.Produto;

public class  ProdutoViewModelResults
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public FornecedorViewModelResults? Fornecedor { get; set; }
    public TipoQuantidadeViewModelResults? TipoQuantidade { get; set; }
    public CategoriaViewModelResults? Categoria { get; set; }

    public ProdutoViewModelResults(){}
    
    public ProdutoViewModelResults(Classes.Produto produto)
    {
        Id = produto.Id;
        Nome = produto.Nome;
        Fornecedor = new FornecedorViewModelResults
        {
            Id = produto.Fornecedor.Id
        };
        TipoQuantidade = new TipoQuantidadeViewModelResults
        {
            Id = produto.Id
        };
        Categoria = new CategoriaViewModelResults
        {
            Id = produto.Categoria.Id,
        };
    }
}