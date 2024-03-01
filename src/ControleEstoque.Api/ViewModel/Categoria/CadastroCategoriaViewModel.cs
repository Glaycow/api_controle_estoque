using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Categoria;

public record CadastroCategoriaViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }

    public Dominio.Classes.Categoria Converter()
    {
        return new Dominio.Classes.Categoria
        {
            Nome = Nome
        };
    }
}