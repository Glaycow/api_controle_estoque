using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleEstoque.Dominio.Base;
using ControleEstoque.Dominio.Enum;

namespace ControleEstoque.Dominio.Classes;

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
    [NotMapped] 
    public Guid ProdutoId { get; set; }
}