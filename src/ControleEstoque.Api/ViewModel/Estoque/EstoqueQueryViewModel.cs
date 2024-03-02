using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Helper;

namespace ControleEstoque.Api.ViewModel.Estoque;

public class EstoqueQueryViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }
    
    [Required(ErrorMessage = "Data de início obrigatória")]
    [DataType(DataType.Date)]
    public DateTime DataInicio { get; set; }
    
    [Required(ErrorMessage = "Data de fim obrigatória")]
    [DataType(DataType.Date)]
    [DataInicioFimValidator]
    public DateTime DataFim { get; set; }
}