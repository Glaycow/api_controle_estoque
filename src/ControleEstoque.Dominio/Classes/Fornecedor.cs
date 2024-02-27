using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Fornecedor : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public string Nome { get; set; }
    [ForeignKey("CategoriaId")]
    public List<Categoria> Categoria { get; set; }
}