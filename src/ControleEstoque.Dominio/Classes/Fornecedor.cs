using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class Fornecedor : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public string Nome { get; set; }
    public List<Categoria> Categoria { get; set; }
}