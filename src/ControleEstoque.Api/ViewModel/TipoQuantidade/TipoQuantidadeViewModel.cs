using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.TipoQuantidade;

public class TipoQuantidadeViewModel
{
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public int Quantidade { get; set; }
}