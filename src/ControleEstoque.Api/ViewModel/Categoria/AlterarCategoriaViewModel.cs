using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Categoria;

public record AlterarCategoriaViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    
    public Dominio.Classes.Categoria Converter()
    {
        return new Dominio.Classes.Categoria
        {
            Nome = Nome,
            Id = Id,
        };
    }
}