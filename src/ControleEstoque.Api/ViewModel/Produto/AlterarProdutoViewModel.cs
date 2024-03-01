using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Produto;

public class AlterarProdutoViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid TipoQuantidadeId { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid FornecedorId { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid CategoriaId { get; set; }
    
    public Dominio.Classes.Produto Converter()
    {
        return new Dominio.Classes.Produto
        {
            Id = Id,
            Nome = Nome,
            TipoQuantidadeId = TipoQuantidadeId,
            FornecedorId = FornecedorId,
            CategoriaId = CategoriaId,
        };
    }
}