using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Categoria : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
}

public class SubGrupo : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    public Fornecedor Fornecedor { get; set; }
    public List<Produto> Produtos { get; set; }
}