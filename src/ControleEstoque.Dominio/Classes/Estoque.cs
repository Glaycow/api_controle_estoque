using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Estoque : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
    public decimal SaldoEstoque { get; set; } = 0;
    public DateTime MesEstoque { get; set; }
}