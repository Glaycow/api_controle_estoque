using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class TipoQuantidade : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "{0} deve ser obrigatório")]
    public int Quantidade { get; set; }
}