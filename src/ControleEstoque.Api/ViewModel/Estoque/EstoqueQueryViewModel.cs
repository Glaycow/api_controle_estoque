using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Helper;

namespace ControleEstoque.Api.ViewModel.Estoque;

public class EstoqueQueryViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }
}