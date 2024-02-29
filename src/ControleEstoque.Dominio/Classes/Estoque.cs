using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;
using ControleEstoque.Dominio.Enum;

namespace ControleEstoque.Dominio.Classes;

public class Estoque : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
    public decimal SaldoEstoque { get; set; } = 0;
    public DateTime MesEstoque { get; set; }
}

public class LancamentoEstoque : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public DateTime DataLancamento { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    [Range(0.01, 9999999.99, ErrorMessage = "Valor maximo permitido é entre {0} é {1}")]
    public decimal Valor { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public TipoLancamento TipoCadastro { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public int Quantidade { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid EstoqueId { get; set; }
    public virtual Estoque Estoque { get; set; }
}