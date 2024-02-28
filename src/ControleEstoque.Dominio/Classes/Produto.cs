using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Produto : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public TipoQuantidade TipoQuantidade { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Categoria Categoria { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Fornecedor Fornecedor { get; set; }
    public List<Estoque> Estoque { get; set; }
}