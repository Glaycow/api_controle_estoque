using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class FornecedorCategoria : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid FornecedorId { get; set; }
    public virtual Fornecedor Fornecedor { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}