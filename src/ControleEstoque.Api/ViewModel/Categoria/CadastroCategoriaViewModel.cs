using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Categoria;

public class CadastroCategoriaViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
}