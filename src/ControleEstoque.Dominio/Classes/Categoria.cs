using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Categoria : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }

    public virtual Fornecedor Fornecedor { get; set; }
}