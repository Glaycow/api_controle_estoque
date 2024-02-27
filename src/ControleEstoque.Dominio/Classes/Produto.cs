using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Produto : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public string Nome { get; set; }
    [Range(0.01, 9999999.99, ErrorMessage = "Valor maximo permitido é entre {0} é {1}")]
    public decimal Valor { get; set; }
    public decimal SaldoQuantidade { get; set; }
    public int Quantidade { get; set; }
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public TipoQuantidade TipoQuantidade { get; set; }
    [ForeignKey("CategoriaId")] 
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public Categoria Categoria { get; set; }
    [ForeignKey("FornecedorId")]
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public Fornecedor Fornecedor { get; set; }
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public int TipoCadastro { get; set; }
}