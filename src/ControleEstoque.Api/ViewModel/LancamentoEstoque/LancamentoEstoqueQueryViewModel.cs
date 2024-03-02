using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.LancamentoEstoque;

public class LancamentoEstoqueQueryViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }
    
    [Required(ErrorMessage = "Data de início obrigatória")]
    [DataType(DataType.Date)]
    public DateTime DataLancamento { get; set; }
}