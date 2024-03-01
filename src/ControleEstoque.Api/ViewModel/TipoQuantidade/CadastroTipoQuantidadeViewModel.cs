using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.TipoQuantidade;

public record CadastroTipoQuantidadeViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public int Quantidade { get; set; }

    public Dominio.Classes.TipoQuantidade Converter()
    {
        return new Dominio.Classes.TipoQuantidade
        {
            Descricao = Descricao,
            Quantidade = Quantidade
        }; 
    }
}