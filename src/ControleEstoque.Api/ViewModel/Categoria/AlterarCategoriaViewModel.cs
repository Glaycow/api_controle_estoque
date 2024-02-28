using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Categoria;

public class AlterarCategoriaViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
}