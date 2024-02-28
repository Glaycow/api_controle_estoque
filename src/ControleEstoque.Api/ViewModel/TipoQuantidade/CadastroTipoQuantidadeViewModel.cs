using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.TipoQuantidade;

public class CadastroTipoQuantidadeViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public int Quantidade { get; set; }
}