using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Fornecedor : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid TipoProdutoId { get; set; }
    public virtual TipoProduto TipoProduto { get; set; }
}