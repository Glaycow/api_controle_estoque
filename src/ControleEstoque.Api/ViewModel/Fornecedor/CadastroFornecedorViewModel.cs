using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Fornecedor;

public record CadastroFornecedorViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public List<Guid> Categoria { get; set; }
}