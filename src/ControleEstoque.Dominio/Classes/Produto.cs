using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Produto : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid TipoQuantidadeId { get; set; }
    public virtual TipoQuantidade TipoQuantidade { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid FornecedorId { get; set; }
    public virtual Fornecedor Fornecedor { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
    public List<Estoque> Estoque { get; set; }
}